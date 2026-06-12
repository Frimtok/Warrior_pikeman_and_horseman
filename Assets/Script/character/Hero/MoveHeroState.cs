using _Scripts.Tiles;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeroState : HeroState
{
    private float _curr = 0;
    private float _speed;
    private Transform transform;
    private NodeBase _targetNode;
    private Hero _hero;
    public MoveHeroState(Hero h) : base(h)
    {
        _speed = h.GetSpeed();
        transform = h.transform;
        _hero = h;
    }

    public override void Enter()
    {
        _speed += 0; // Бонусная скорость(пока 0)
        Debug.Log("Enter state Move");
    }
    public override void Exit()
    {
        Debug.Log("exit state Move");
    }

    public override void Update() 
    {
        Debug.Log("Update state Move");
        _targetNode = ManagerState.GetTargetNode();
        if (_targetNode == null) return;    
        if (Vector3.Distance(transform.position, _targetNode.transform.position) < 0.01f)
        {
            transform.position = _targetNode.transform.position;
            ManagerState.IncrementIndex();
            _heroesSatet.SetState<IdleHeroState>();
        }
        MoveInNode();
    }
    public void MoveInNode()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,_targetNode.transform.position,step);
    }

}
