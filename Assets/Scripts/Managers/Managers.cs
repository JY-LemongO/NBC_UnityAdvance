using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    #region Core
    ResourceManager _resource = new ResourceManager();
    UIManager _uiManager = new UIManager();

    public static ResourceManager RM => Instance?._resource;
    public static UIManager UI => Instance?._uiManager;    
    #endregion

    private void Awake()
    {
        Init();
    }

    private static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if(go == null)
            {
                go = new GameObject("@Managers");
                go.AddComponent<Managers>();
            }

            s_instance = go.GetComponent<Managers>();
            DontDestroyOnLoad(go);

        }
    }
}
