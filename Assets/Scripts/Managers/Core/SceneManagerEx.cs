using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene => UnityEngine.Object.FindObjectOfType<BaseScene>();

    public void LoadScene(Define.Scenes scene)
    {
        Managers.Clear();

        SceneManager.LoadScene(GetSceneName(scene));
    }

    private string GetSceneName(Define.Scenes scene) => Enum.GetName(typeof(Define.Scenes), scene);

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
