
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using System;
using _Scripts.Tiles;

public abstract class Hero : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] public float Speed;
    [SerializeField] public float SpeedRotate;
    [SerializeField] public NodeBase _hexTargetEnd;
    [SerializeField] public NodeBase _hexTargetNow;
    private HeroState StateCurr { get; set; }
    private Dictionary<Type, HeroState> _state = new Dictionary<Type, HeroState>();
    public void AddSatte(HeroState state) 
    {
        _state.Add(state.GetType(), state);
    }
    public void SetState<T>() where T : HeroState 
    {
        var t = typeof(T);
        if (StateCurr != null && StateCurr.GetType() == t) return;
        if(_state.TryGetValue(t, out var newState)) 
        {
            StateCurr?.Exit();
            StateCurr = newState;
            StateCurr.Enter();

        }
    }
    public void Update()
    {
        _hexTargetEnd = HexNode.now;
        StateCurr?.Update();
    }
}
