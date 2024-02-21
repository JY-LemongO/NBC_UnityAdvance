using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    private void Awake()
    {
        Init();
    }

    protected abstract void Init();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];

        _objects.Add(typeof(T), objects);

        for(int i = 0; i < names.Length; i++)
        {
            // To Do - ������ ���� GameObject�� ���� ���� �߰�
            objects[i] = Util.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                Debug.Log($"���ε忡 �����߽��ϴ�. : {names[i]}");
        }
    }

    protected void BindButton(Type type) => Bind<Button>(type);

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects;

        if(_objects.TryGetValue(typeof(T), out objects) == false)
        {
            Debug.Log($"�ش�Ű�� ����� ���� �����ϴ�. : {typeof(T).Name}");
            return null;
        }

        return objects[index] as T;
    }

    protected Button GetButton(int index) => Get<Button>(index);
}
