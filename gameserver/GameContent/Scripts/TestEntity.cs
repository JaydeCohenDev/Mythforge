using ScriptApi;

namespace GameContent.Scripts;

public class TestEntity : EntityScript
{
    public override void OnGreet(Entity greeter)
    {
        greeter.Tell(new Message("Hello there!!"));
    }
}