namespace GameServer.Core.Auth;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Email { get; set; }
    public Player Player { get; set; }
    public List<string> Permissions { get; set; } = [];
}