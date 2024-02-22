using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scenes SceneType { get; private set; }

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        GameObject eventSystem = GameObject.Find("@EventSystem");
        if (eventSystem == null)
            Managers.RM.Instantiate("UI/@EventSystem");
    }

    public abstract void Clear();
}
