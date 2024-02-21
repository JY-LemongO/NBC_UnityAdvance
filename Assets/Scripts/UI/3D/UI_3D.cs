using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_3D : UI_Base
{
    protected bool _canUseUI = true;
    protected TitleSceneCameraController _cam;
    protected override void Init()
    {
        Managers.UI.SetCanvas(gameObject, false, true);
        _cam = Camera.main.GetComponent<TitleSceneCameraController>();
    }

    protected void GoToUI(CameraStateBase state)
    {
        if (!_canUseUI)
            return;
        
        if (_cam == null)
        {
            Debug.Log("���� ķ�� ��Ʈ�ѷ��� �����Ǿ����� �ʽ��ϴ�.");
            return;
        }

        _cam.StateMachine.ChangeState(state);
    }
}
