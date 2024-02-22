using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        // To Do - Instantiate 의 Load부분을 여기서 담당.
        // 풀링 대상이면 Resources Load 하지 않고 Pool 내부의 Original 반환.
        T type = Resources.Load<T>($"prefabs/{path}");

        return type;
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Resources.Load<GameObject>($"prefabs/{path}");

        if(original == null)
        {
            Debug.Log($"리소스 불러오기에 실패했습니다. : {path}");
            return null;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        return go;
    }
    
    public void Destroy(GameObject go)
    {
        //To Do - 풀링 대상을 확인하는 Destroy함수 작성
    }
}
