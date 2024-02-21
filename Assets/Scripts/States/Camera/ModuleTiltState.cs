using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleTiltState : CameraStateBase
{
    public ModuleTiltState(CameraStateMachine stateMachine) : base(stateMachine)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        mStart = Quaternion.Euler(15, 180, 0);
        _stateMachine.Controller.ChangeCameraLerp(mStart);        
    }
}
