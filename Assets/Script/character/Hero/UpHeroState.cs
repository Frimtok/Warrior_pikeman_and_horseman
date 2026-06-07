using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHeroState : HeroState
{
    Hero h;
    [SerializeField] private float _speed = 0.40f, _currUp = 20;
    private Transform _transform;
    private Vector3 start, startUp;
    public UpHeroState(Hero h) : base(h)
    {
        _transform = h.transform;
        start = h.transform.position;
        startUp = new Vector3(h.transform.position.x, h.transform.position.y + 50, h.transform.position.z);
    }
    void IsUp()
    {
          _currUp = Mathf.MoveTowards(_currUp, 1, _speed * Time.deltaTime);
          Debug.Log(_currUp);
        _transform.position = Vector3.Lerp(start, startUp, _currUp);
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
        IsUp();
        if (_transform.position == startUp)
        {
            _heroesSatet.SetState<MoveHeroState>();
        }
    }
}
