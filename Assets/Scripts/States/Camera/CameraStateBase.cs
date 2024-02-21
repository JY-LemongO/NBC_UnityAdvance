using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateBase : IState
{
    protected CameraStateMachine _stateMachine;
    
    protected Transform mTrans;
    protected Quaternion mStart;
    protected Vector2 mRot = Vector2.zero;    

    public CameraStateBase(CameraStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        mTrans = stateMachine.Controller.transform;
        mStart = Quaternion.identity;
    }

    public virtual void Enter() { }    

    public virtual void Exit() { }   

    public virtual void FixedUpdate()
    {
        if (_stateMachine.Controller.IsChanging)
            return;

        Vector3 pos = Input.mousePosition;

        float halfWidth = Screen.width * 0.5f;
        float halfHeight = Screen.height * 0.5f;
        float x = Mathf.Clamp((pos.x - halfWidth) / halfWidth, -1f, 1f);
        float y = Mathf.Clamp((pos.y - halfHeight) / halfHeight, -1f, 1f);
        mRot = Vector2.Lerp(mRot, new Vector2(x, y), Time.deltaTime * 5f);

        mTrans.localRotation = mStart * Quaternion.Euler(-mRot.y * _stateMachine.Range.y, mRot.x * _stateMachine.Range.x, 0f);
    }    
}
