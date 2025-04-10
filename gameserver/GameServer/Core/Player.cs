using System;
using GameServer.Content;
using GameServer.Content.Commands;
using GameServer.Core.Ability;
using GameServer.Core.EntityTraits;
using GameServer.Core.Skill;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core;

public class Player : Entity
{
    public static Dictionary<string, Player> All { get; } = [];
    public string ConnectionId { get; private set; }
    public int Gold { get; set; } = 100;

    public Player(string connectionId)
    {
        Name = "Player";
        ConnectionId = connectionId;
        AddTraits(new Damageable(100), new Fighting(new BasicAttack
        {
            Name = "Punch",
            Description = "Lash out with your fists against your target!"
        }), new SkillUser(), new InventoryTrait(), new EquipmentUser<HumanoidEquipmentSlot>());
        All.Add(ConnectionId, this);

        var skillUser = GetTrait<SkillUser>();
        skillUser?.LevelUpSkill(Skills.Adventuring);
    }

    public override void OnEnterRoom(Room room)
    {
        if (CurrentRoom is not null)
            Game.HubContext.Groups.RemoveFromGroupAsync(ConnectionId, CurrentRoom.Name);

        base.OnEnterRoom(room);

        Game.HubContext.Groups.AddToGroupAsync(ConnectionId, room.Name);
        LookCommand.SendRoomLook(this);
    }

    public Task SendAsync(params object[] args)
        => Game.HubContext.Clients.Client(ConnectionId).SendAsync("ShowMessage", args);
}
