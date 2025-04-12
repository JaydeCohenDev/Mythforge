using System;

namespace GameServer.Core;

public interface ICommand
{
    public string[] GetAliases();
    public Task Execute(Player player, string[] args);
    public virtual bool CanExecute(Player player, string[] args) => true;
}
