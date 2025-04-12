namespace ScriptApi.TestScripts;

public class TestEntity : EntityScript
{
    public override void OnGreet(Entity greeter)
    {
        greeter.Tell("Hello there!");
    }
}