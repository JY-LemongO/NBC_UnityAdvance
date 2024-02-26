using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBase : Parts
{
    [field: SerializeField] public LowerPartsSO LowerSO { get; private set; }

    public override void Move()
    {
        Vector3 MoveDir = GetMoveDirection();
        MoveDir.y = _playerController.Rigidbody.velocity.y;
        
        _playerController.Rigidbody.velocity = MoveDir * LowerSO.Power * Time.deltaTime;
    }

    private Vector3 GetMoveDirection()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0;
        right.y = 0;

        return forward * _playerController.MoveDirection.y + right * _playerController.MoveDirection.x;
    }
}
