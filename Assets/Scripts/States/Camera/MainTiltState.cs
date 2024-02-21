using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTiltState : CameraStateBase
{
    public MainTiltState(CameraStateMachine stateMachine) : base(stateMachine)
    {
    }    
    
    public override void Enter()
    {
        base.Enter();

        mStart = Quaternion.Euler(0, 0, 0);
        _stateMachine.Controller.ChangeCameraLerp(mStart);
    }
}
