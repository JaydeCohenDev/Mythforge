using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace GameServer.Core.Database;

public static class DbContextPreloader
{
    public static async Task PreloadDatabaseAsync(DbContext context, Action<string> logger = null)
    {
        logger ??= _ => { }; // No-op if no logger provided

        var totalStopwatch = Stopwatch.StartNew();
        logger("🚀 Starting database preload...");

        var visited = new HashSet<object>();

        // Step 1: Load all root DbSets with timing
        var dbSetProperties = context.GetType().GetProperties()
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .ToList();

        foreach (var property in dbSetProperties)
        {
            var entityType = property.PropertyType.GenericTypeArguments[0];
            var dbSet = property.GetValue(context);
            var loadMethod = typeof(EntityFrameworkQueryableExtensions)
                .GetMethods()
                .FirstOrDefault(m => m.Name == nameof(EntityFrameworkQueryableExtensions.LoadAsync)
                                     && m.IsGenericMethod
                                     && m.GetParameters().Length == 2 // source + cancellationToken
                );


            if (loadMethod != null)
            {
                var genericLoadMethod = loadMethod.MakeGenericMethod(entityType);
                var stopwatch = Stopwatch.StartNew();
                logger($"📥 Loading DbSet<{entityType.Name}>...");
                var task = (Task)genericLoadMethod.Invoke(null, new object[] { dbSet, CancellationToken.None });
                await task;
                stopwatch.Stop();

                // Estimate count
                var count = ((IQueryable)dbSet).Cast<object>().Count();
                logger($"✅ Loaded {count} {entityType.Name} entities in {stopwatch.Elapsed.TotalSeconds:F2}s");
            }
        }

        logger("🔍 Root entities loaded. Starting recursive navigation load...");

        // Step 2: Recursively load navigations with progress reporting
        var entries = context.ChangeTracker.Entries().ToList();
        int totalEntries = entries.Count;
        int processedEntries = 0;

        foreach (var entry in entries)
        {
            await RecursiveLoadAsync(entry.Entity, context, visited, logger, processedEntries, totalEntries);
        }

        totalStopwatch.Stop();
        logger($"🎉 Database preload complete in {totalStopwatch.Elapsed.TotalSeconds:F2}s");
    }

    private static async Task RecursiveLoadAsync(
        object entity,
        DbContext context,
        HashSet<object> visited,
        Action<string> logger,
        int processedEntries,
        int totalEntries)
    {
        if (entity == null || !visited.Add(entity))
            return;

        var entry = context.Entry(entity);

        // Progress log (optional, logs every 100 entities to avoid spam)
        Interlocked.Increment(ref processedEntries);
        if (processedEntries % 100 == 0)
        {
            logger($"⏳ Loading navigations... {processedEntries}/{totalEntries} entities processed");
        }

        foreach (var navigation in entry.Navigations)
        {
            var navigationProperty = navigation.Metadata as INavigationBase;

            // Skip navigations without member info (many-to-many virtual links)
            if (navigationProperty == null || navigationProperty is not INavigation navigationWithMember || navigationWithMember?.ClrType == null)
            {
                continue;
            }

            if (!navigation.IsLoaded)
            {
                await navigation.LoadAsync();
                logger($"🔗 Loaded navigation: {entry.Metadata.ClrType.Name}.{navigation.Metadata.Name}");
            }

            if (navigation.CurrentValue is IEnumerable<object> collection)
            {
                foreach (var item in collection)
                {
                    await RecursiveLoadAsync(item, context, visited, logger, processedEntries, totalEntries);
                }
            }
            else
            {
                await RecursiveLoadAsync(navigation.CurrentValue, context, visited, logger, processedEntries, totalEntries);
            }
        }
    }
}