using _Scripts.Tiles;
using UnityEngine;

public class RotateHeroState : HeroState
{
    Transform _transform;
    NodeBase _targetNode;
    private float rotationSpeed;
    Hero _hero;
    public RotateHeroState(Hero h, Transform t, float s) : base(h) 
    {
        _transform = t;
        _hero = h;
        rotationSpeed = s;
    }
    public override void Enter()
    {
        Debug.Log("enter state rotate");
    }
    public override void Exit()
    {
        Debug.Log("exit state rotate");
    }

    public override void Update()
    {
        _targetNode = _hero._hexTargetNow;
        if (_targetNode == null)
        {
            return;
        }
        Vector3 direction = _targetNode.transform.position - _transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            _transform.eulerAngles = new Vector3(-90, _transform.eulerAngles.y, _transform.eulerAngles.z);
        }
        float angleDiff = Mathf.Abs(_targetNode.transform.eulerAngles.y - _transform.eulerAngles.y);
        if (angleDiff < 0.5f)
        {
            _heroesSatet.SetState<RotateHeroState>();
        }
    }
}
