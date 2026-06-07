using _Scripts.Tiles;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMove : MonoBehaviour
{
    public static ManagerMove Instance;
    public event System.Action<List<NodeBase>> MoveCommande;

    private void Awake()  => Instance = this;

    public void RequestMove(List<NodeBase> path) 
    {
        MoveCommande?.Invoke(path);
    }
}
