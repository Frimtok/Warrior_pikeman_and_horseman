using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMExsample : MonoBehaviour
{
    [SerializeField]private Hero _hero;
    void Start()
    {
       _hero.AddSatte(new MoveHeroState(_hero,_hero.transform, _hero.Speed));
       _hero.AddSatte(new IdleHeroState(_hero));
       _hero.AddSatte(new RotateHeroState(_hero, _hero.transform, _hero.SpeedRotate));
       _hero.SetState<IdleHeroState>();
    }

    // Update is called once per frame
    void Update()
    {
        _hero.Update();
    }
}
