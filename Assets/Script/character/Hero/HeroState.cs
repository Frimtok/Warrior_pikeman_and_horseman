
using System.Collections.Generic;
using UnityEngine.Experimental.GlobalIllumination;

public abstract class HeroState
{
    protected readonly Hero _heroesSatet;
    protected HeroState(Hero h)
    {
        _heroesSatet = h;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { } 

}
