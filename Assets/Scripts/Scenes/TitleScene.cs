using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleScene : BaseScene
{
    public override void Init()
    {
        base.Init();
        
        Managers.UI.Show3DWorldUI<UI_Title3D>();
        Managers.UI.Show3DWorldUI<UI_Module3D>();
        Managers.RM.Instantiate("Module/Module_Assembleable");
        Managers.RM.Instantiate("Module/Shower");

        Managers.Module.Init();
    }

    public override void Clear()
    {
        
    }
}
