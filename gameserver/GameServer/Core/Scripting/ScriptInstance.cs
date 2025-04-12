using System.Reflection;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace GameServer.Core.Scripting;

public class ScriptInstance
{
    public int Id { get; set; }
    public ScriptFile ScriptFile { get; set; }
        
    private Assembly? _scriptAssembly;
    private AssemblyLoadContext? _context;

    public ScriptInstance() {}
    
    public ScriptInstance(ScriptFile script)
    {
        ScriptFile = script;
        LoadScript(script.SourceCode);
    }

    public void LoadScript(string code)
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

        List<MetadataReference> references =
        [
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Task).Assembly.Location)
        ];

        var compilation = CSharpCompilation.Create(
            "ScriptAssembly",
            [syntaxTree],
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var ms = new MemoryStream();
        EmitResult result = compilation.Emit(ms);
        
        if (!result.Success)
        {
            foreach (Diagnostic diagnostic in result.Diagnostics)
            {
                Console.WriteLine(diagnostic.ToString());
            }
            return;
        }
        
        ms.Seek(0, SeekOrigin.Begin);

        UnloadPreviousAssembly();

        _context = new AssemblyLoadContext("ScriptContext", isCollectible: true);
        _scriptAssembly = _context.LoadFromStream(ms);

        Console.WriteLine("Script loaded!");
    }
    
    private void UnloadPreviousAssembly()
    {
        if (_context == null) return;
        
        _context.Unload();
        _context = null;
        _scriptAssembly = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}