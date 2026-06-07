using _Scripts.Tiles;
using System.Collections.Generic;
using UnityEngine;

public class Horseman : Hero
{
    int nowHex = 1;
    Quaternion rotation;
    private float targetAngleZ;
    private float _curr = 0, _target = 1;
    [SerializeField] private float _currUp = 0, speedUp;
    bool go = false, r = false;
    private void Start()
    {
        rotation = transform.rotation;
        targetAngleZ = transform.eulerAngles.z;
        ManagerMove.Instance.MoveCommande += MoveAlongPath;
    }

    private void Update()
    {
        ManagerMove.Instance.RequestMove(HexNode.selectedPath);
    }

    void MoveAlongPath(List<NodeBase> path)
    {
        //return;
        //if (!r)RotateInNode();
        //if (!go && r)IsUp();
        //bool isRun = go && nowHex < _hexNode.Length;
        
    }
    void IsUp() 
    {
        //_currUp = Mathf.MoveTowards(_currUp, _target, Speed * Time.deltaTime);
        //Debug.Log(_currUp);
        //transform.position = Vector3.Lerp(start, startUp, _currUp);
        //if (transform.position == startUp)
        //{
        //    go = true;
        //}
    }
}
