using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Title3D : UI_3D
{
    enum Buttons
    {
        Play_Btn,
        Module_Btn,
        Exit_Btn,
    }

    protected override void Init()
    {
        base.Init();

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Play_Btn).onClick.AddListener(() => Managers.Scene.LoadScene(Define.Scenes.Main)); // To Do - �� ��ȯ �� ��� ����
        GetButton((int)Buttons.Module_Btn).onClick.AddListener(() => GoToUI(_cam.StateMachine.moduleState));
        GetButton((int)Buttons.Exit_Btn); // To Do - ������ ���� �� ������ ����
    }    
}
