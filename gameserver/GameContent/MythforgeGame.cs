using GameContent.Flows;
using ScriptApi;
using ScriptApi.Flow;

namespace GameContent;

public class MythforgeGame : GameManagerBase
{
    public override ScriptFlow GetInitialFlow()
        => new LoginFlow();
}