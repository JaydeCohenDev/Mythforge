﻿using ScriptApi;

namespace GameContent.Scripts;

public class Screamer : EntityScript
{
    public override void OnUpdate()
    {
        Entity.GetRoom()?.Tell(new Message("Ahh!"));
    }
}