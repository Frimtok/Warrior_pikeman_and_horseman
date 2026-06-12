using _Scripts.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMExsample : MonoBehaviour
{
    [SerializeField]private Hero _hero;
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
     //   ManagerMove.Instance.RequestMove(HexNode.selectedPath);
    }

    private void MoveAlongPath(List<NodeBase> path) 
    {
       // _hero.SetState<MoveHeroState>();
    }
}
