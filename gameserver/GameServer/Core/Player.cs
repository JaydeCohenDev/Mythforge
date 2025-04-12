using System;
using GameServer.Content;
using GameServer.Content.Commands;
using GameServer.Core.Ability;
using GameServer.Core.Auth;
using GameServer.Core.EntityTraits;
using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core;

public class Player : Entity
{
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public Room LoginRoom { get; set; }

    public int Gold { get; set; } = 100;

    public Player()
    {
        
        AddTraits(new Damageable(100), new Fighting(new BasicAttack
        {
            Name = "Punch",
            Description = "Lash out with your fists against your target!"
        }), new SkillUser(), new InventoryTrait(), new EquipmentUser<HumanoidEquipmentSlot>());

        var skillUser = GetTrait<SkillUser>();
        skillUser?.LevelUpSkill(Skills.Adventuring);
    }

    public string? GetConnectionId()
    {
        return GameHub.GetPlayerSession(this)?.ConnectionId;
    }

    public override void OnEnterRoom(Room room)
    {
        if (CurrentRoom is not null)
        {
            
            Game.HubContext.Groups.RemoveFromGroupAsync(GetConnectionId(), CurrentRoom.Name);
        }

        LoginRoom = room;
        base.OnEnterRoom(room);

        Game.HubContext.Groups.AddToGroupAsync(GetConnectionId(), room.Name);
        LookCommand.SendRoomLook(this);
    }

    public Task SendAsync(params object[] args)
        => Game.HubContext.Clients.Client(GetConnectionId()).SendAsync("ShowMessage", args);
}
