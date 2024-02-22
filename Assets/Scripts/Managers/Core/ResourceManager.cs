using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        // To Do - Instantiate �� Load�κ��� ���⼭ ���.
        // Ǯ�� ����̸� Resources Load ���� �ʰ� Pool ������ Original ��ȯ.
        T type = Resources.Load<T>($"prefabs/{path}");

        return type;
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Resources.Load<GameObject>($"prefabs/{path}");

        if(original == null)
        {
            Debug.Log($"���ҽ� �ҷ����⿡ �����߽��ϴ�. : {path}");
            return null;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        return go;
    }
    
    public void Destroy(GameObject go)
    {
        //To Do - Ǯ�� ����� Ȯ���ϴ� Destroy�Լ� �ۼ�
    }
}
