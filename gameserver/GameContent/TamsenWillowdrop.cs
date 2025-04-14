using ScriptApi;

public class TamsenWillowdrop : EntityScript
{
    public override void OnUpdate()
    {
        
    }

    public override void OnGreet(Entity greeter)
    {
        greeter.Tell("Hello there!!");
    }
}