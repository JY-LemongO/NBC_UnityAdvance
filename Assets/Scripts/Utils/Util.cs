using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (!recursive)
        {
            //To Do - UI �̿��� �۾��� ���� resurcive true ������ �� ����
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }
}