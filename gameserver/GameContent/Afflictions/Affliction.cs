﻿using ScriptApi;

namespace GameContent.Afflictions;

public abstract class Affliction
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract void Apply(Entity target);
}
