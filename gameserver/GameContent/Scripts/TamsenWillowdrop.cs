using ScriptApi;

namespace GameContent.Scripts;

public class TamsenWillowdrop : EntityScript
{
    public override void OnUpdate()
    {
        
    }

    public override void OnGreet(Entity greeter)
    {
        greeter.Tell(new Message("Hello there!!"));
    }
}