using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Module3D : UI_3D
{
    enum Buttons
    {
        UpperParts_Btn,
        LowerParts_Btn,
        Back_Btn,
    }

    protected override void Init()
    {
        base.Init();

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Back_Btn).onClick.AddListener(() => GoToUI(_cam.StateMachine.mainState));
    }
}
