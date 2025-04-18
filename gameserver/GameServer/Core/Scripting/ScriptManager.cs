using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using Microsoft.EntityFrameworkCore;
using ScriptApi;

namespace GameServer.Core.Scripting;

public static class ScriptManager
{
    private class LoadedScriptAssembly
    {
        public Assembly Assembly { get; set; }
        public AssemblyLoadContext LoadContext { get; set; }
    }
    
    private static readonly string ScriptsFolder = Path.Combine(AppContext.BaseDirectory, "Scripts");
    private static readonly FileSystemWatcher Watcher;
    private static readonly ConcurrentDictionary<string, LoadedScriptAssembly> LoadedAssemblies = [];
    private static readonly object LockObject = new();

    static ScriptManager()
    {
        // Load existing DLLs at startup
        LoadExistingDlls();
        
        // Initialize the FileSystemWatcher
        Watcher = new FileSystemWatcher(ScriptsFolder, "*.dll")
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
            EnableRaisingEvents = true
        };

        Watcher.Changed += OnDllChanged;
        Watcher.Created += OnDllChanged;
        Watcher.Deleted += OnDllDeleted;
    }
    
    public static T? CreateScript<T>(string scriptName) where T : ScriptBase
    {
        lock (LockObject)
        {
            // Look for the script in loaded assemblies
            foreach (var assembly in LoadedAssemblies.Values)
            {
                try
                {
                    // Find the script type with the specified name
                    var scriptType = assembly.Assembly.GetTypes()
                        .FirstOrDefault(type => type.IsSubclassOf(typeof(ScriptBase)) && type.Name.Equals(scriptName, StringComparison.InvariantCultureIgnoreCase));

                    if (scriptType != null)
                    {
                        // Create and return an instance of the script
                        var script = Activator.CreateInstance(scriptType) as T;
                        script?.TrackChanges();
                        return script;
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    // Handle issues with loading types from assembly (e.g., missing dependencies)
                    Console.WriteLine($"Error loading types from assembly: {ex.Message}");
                }
            }

            Console.WriteLine($"Script '{scriptName}' not found in any loaded assemblies.");
            return null;
        }
    }
    
    private static void OnDllChanged(object sender, FileSystemEventArgs e)
    {
        lock (LockObject)
        {
            try
            {
                Console.WriteLine($"Detected DLL change: {e.FullPath}");

                // Load or reload the assembly
                string dllPath = e.FullPath;
                var assemblyName = Path.GetFileNameWithoutExtension(dllPath);

                // Check if already loaded, replace if needed
                if (LoadedAssemblies.ContainsKey(assemblyName))
                {
                    LoadedAssemblies[assemblyName] = ReloadAssembly(dllPath);
                    Console.WriteLine($"Reloaded assembly: {assemblyName}");
                }
                else
                {
                    var assembly = LoadAssembly(dllPath);
                    if (assembly != null)
                    {
                        LoadedAssemblies[assemblyName] = assembly;
                        Console.WriteLine($"Loaded new assembly: {assemblyName}");
                    }
                }
                
                PostScriptPackageLoad(LoadedAssemblies[assemblyName]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling DLL change: {ex.Message}");
            }
        }
    }

    private static void PostScriptPackageLoad(LoadedScriptAssembly? scriptPackage)
    {

        if (scriptPackage == null) return;
        scriptPackage.Assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ScriptApi.ICommand)) && !t.IsAbstract)
            .ToList().ForEach(t =>
            {
                if (Activator.CreateInstance(t) is ScriptApi.ICommand command) 
                    CommandHandler.RegisterCommand(command);
            });
    }

        private static void OnDllDeleted(object sender, FileSystemEventArgs e)
        {
            lock (LockObject)
            {
                var assemblyName = Path.GetFileNameWithoutExtension(e.FullPath);

                if (LoadedAssemblies.ContainsKey(assemblyName))
                {
                    LoadedAssemblies.TryRemove(assemblyName, out _);
                    Console.WriteLine($"Unloaded assembly: {assemblyName}");
                }
                
                PostScriptPackageLoad(null);
            }
        }

        private static LoadedScriptAssembly LoadAssembly(string path)
        {
            if (!File.Exists(path))
                return null;

            try
            {
                Console.WriteLine($"Loading assembly: {path}");
                
                var context = new AssemblyLoadContext(path, true);
                
                using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                var assembly = context.LoadFromStream(stream);
                
                Console.WriteLine($"Assembly loaded: {assembly.FullName}");
                Console.WriteLine("Contained Types: ");
                var filteredTypes = assembly.GetTypes()
                    .Where(
                        t => !t.IsDefined(typeof(CompilerGeneratedAttribute), inherit: true) &&
                             !t.Name.StartsWith("<")
                    ) // Exclude compiler-generated types
                    .ToList();

                filteredTypes.ForEach(t =>
                {
                    Console.WriteLine($"  - {t.FullName}");
                });
                
                
                
                return new LoadedScriptAssembly
                {
                    Assembly = assembly,
                    LoadContext = context
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load assembly: {ex.Message}");
                return null;
            }

            
        }

        private static LoadedScriptAssembly ReloadAssembly(string path)
        {
            var assemblyName = Path.GetFileNameWithoutExtension(path);
            if (LoadedAssemblies.TryGetValue(assemblyName, out var oldAssembly))
            {
                Console.WriteLine($"Unloading old assembly: {assemblyName}");
                
                CommandHandler.Commands.Clear();
                LoadedAssemblies.TryRemove(assemblyName, out _);
                oldAssembly.LoadContext.Unload();

                // Force garbage collection to ensure unload happens fast
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            
            // To "reload" an assembly, we isolate it using a new AssemblyLoadContext
            return LoadAssembly(path);
        }


    private static void LoadExistingDlls()
    {
        try
        {
            if (!Directory.Exists(ScriptsFolder))
                Directory.CreateDirectory(ScriptsFolder);

            var dllFiles = Directory.GetFiles(ScriptsFolder, "*.dll");
            foreach (var dllPath in dllFiles)
            {
                var assemblyName = Path.GetFileNameWithoutExtension(dllPath);
                if (!LoadedAssemblies.ContainsKey(assemblyName))
                {
                    var assembly = LoadAssembly(dllPath);
                    if (assembly != null)
                    {
                        LoadedAssemblies[assemblyName] = assembly;
                        PostScriptPackageLoad(assembly);
                    }
                }
            }
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading existing DLLs: {ex.Message}");
        }
    }

    public static void Init()
    {
        // Triger load
    }

    public static T? Get<T>() where T : class
    {
        lock (LockObject)
        {
            foreach (LoadedScriptAssembly assembly in LoadedAssemblies.Values)
            {
                Console.WriteLine($"Looking for script type: {typeof(T).FullName}");
                
                try
                {
                    // Find the script type with the specified name

                    
                    var types = assembly.Assembly.GetTypes().ToList();
                        foreach (var t in types)
                        {
                          if(t.IsAssignableTo(typeof(T)) && !t.IsAbstract)
                              return Activator.CreateInstance(t) as T;
                        };
                }
                catch (ReflectionTypeLoadException ex)
                {
                    // Handle issues with loading types from assembly (e.g., missing dependencies)
                    Console.WriteLine($"Error loading types from assembly: {ex.Message}");
                }
            }
        }

        return null;
    }
}