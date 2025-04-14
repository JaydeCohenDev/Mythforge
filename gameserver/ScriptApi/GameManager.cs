using ScriptApi.Flow;

namespace ScriptApi;

public abstract class GameManagerBase
{
    public abstract ScriptFlow GetInitialFlow();
}