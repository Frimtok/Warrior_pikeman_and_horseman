using _Scripts.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IdleHeroState : HeroState
{
    private Hero h;
    public IdleHeroState(Hero h) : base(h)
    {
        this.h = h;
    }
    public override void Enter()
    {
        Debug.Log("enter state Idle");
    }
    public override void Exit()
    {
        Debug.Log("exit state Idle");
    }
    public override void Update()  
    {
        Debug.Log("update state Idle");
    }

}
