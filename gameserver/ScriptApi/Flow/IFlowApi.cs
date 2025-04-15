namespace ScriptApi.Flow;

public interface IFlowApi
{
    void StoreTemp(string name, object value);
    object? GetTemp(string name);
    void RemoveTemp(string name);
    Task<bool> HasAccount(string accountName);
    Task StartFlow(ScriptFlow flow);
    Task<bool> ValidateLogin(string accountName, string pass);
    Task TellUser(Message message);
    void RestartCurrentFlow();
    void FinalizeLogin();
    Task ResumeMainGameFlow();
    Task<Player> CreateAccount(string accountName, string password);
    void RestartStep();
}