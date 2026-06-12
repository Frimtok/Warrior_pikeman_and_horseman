
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using System;
using _Scripts.Tiles;

public abstract class Hero : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] public float SpeedRotate;
    private HeroState StateCurr { get; set; }
    private Dictionary<Type, HeroState> _state = new Dictionary<Type, HeroState>();
    public void AddSatte(HeroState state) 
    {
        _state.Add(state.GetType(), state);
    }
    public HeroState CurrentState => StateCurr;
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
    public void Start()
    {
        AddSatte(new MoveHeroState(this));
        AddSatte(new IdleHeroState(this));
        AddSatte(new RotateHeroState(this));
        // ManagerMove.Instance.MoveCommande += MoveAlongPath;
        SetState<IdleHeroState>();
    }

    public void Update()
    {
        StateCurr?.Update();
    }

    public float GetSpeed() 
    {
        return _speed;
    }
}
