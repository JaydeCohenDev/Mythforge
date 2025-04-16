using ScriptApi.Flow;

namespace ScriptApi;

public abstract class GameManagerBase
{
    public abstract void SupplyScriptApi(IScriptApi api);
    public abstract ScriptFlow GetInitialFlow();
}