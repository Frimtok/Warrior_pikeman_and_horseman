using _Scripts.Tiles;
using System.Security.Cryptography;
using UnityEngine;

public class ManagerState : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private NodeBase _targetNode;
    [SerializeField] private static int _index = 1;
    public void OnMove()
    {
        _hero.SetState<MoveHeroState>();
    }
    private void Update()
    {
        if (GetTargetNode() != null && _hero.CurrentState is IdleHeroState)
        {
            _hero.SetState<RotateHeroState>();
        }
    }
    public void SetTargetNode(NodeBase target)
    {
        _targetNode = target;
    }

    public static NodeBase GetTargetNode()
    {
        if (HexNode.selectedPath != null)
        {
            if (_index >= HexNode.selectedPath.Count) return HexNode.now;
            return HexNode.selectedPath[_index];
        }
        else
        {
            return null;
        }
    }
    public static void IncrementIndex() 
    {
        _index++;
    }
}
