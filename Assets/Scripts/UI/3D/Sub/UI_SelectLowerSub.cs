using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelectLowerSub : UI_Base
{
    enum Buttons
    {
        Previous_Btn,
        Next_Btn,
    }

    enum Texts
    {
        Name_Text,
        Desc_Text,
    }

    protected override void Init()
    {
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.Previous_Btn);
        GetButton((int)Buttons.Next_Btn);
    }
}
