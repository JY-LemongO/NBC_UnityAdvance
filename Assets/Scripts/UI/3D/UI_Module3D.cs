using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Module3D : UI_3D
{
    enum GameObjects
    {
        Selector,
        
    }

    enum Buttons
    {
        UpperParts_Btn,
        LowerParts_Btn,
        Back_Btn,

        Previous_Btn,
        Next_Btn,
    }

    private GameObject _selector;

    protected override void Init()
    {
        base.Init();

        // To Do - Action ¿¬°á

        BindButton(typeof(Buttons));
        BindGameObject(typeof(GameObjects));

        _selector = GetGameObject((int)GameObjects.Selector);
        _selector.SetActive(false);

        GetButton((int)Buttons.Back_Btn).onClick.AddListener(() => GoToUI(_cam.StateMachine.mainState));        
        GetButton((int)Buttons.LowerParts_Btn).onClick.AddListener(() => _selector.SetActive(true));


        GetButton((int)Buttons.Next_Btn).onClick.AddListener(() => Managers.Module.ChangeLowerParts(1));
        GetButton((int)Buttons.Previous_Btn).onClick.AddListener(() => Managers.Module.ChangeLowerParts(-1));
    }
}
