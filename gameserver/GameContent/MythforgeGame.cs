using GameContent.Flows;
using ScriptApi;
using ScriptApi.Flow;

namespace GameContent;

public class MythforgeGame : GameManagerBase
{
    public static IScriptApi Api;

    public override void SupplyScriptApi(IScriptApi api)
    {
        Api = api;
    }

    public override ScriptFlow GetInitialFlow()
        => new LoginFlow();
}