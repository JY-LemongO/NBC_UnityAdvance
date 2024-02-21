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
            // Gameobject 타입
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                Debug.Log($"바인드에 실패했습니다. : {names[i]}");
        }
    }

    protected void BindGameObject(Type type) => Bind<GameObject>(type);
    protected void BindButton(Type type) => Bind<Button>(type);
    protected void BindText(Type type) => Bind<Text>(type);

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects;

        if(_objects.TryGetValue(typeof(T), out objects) == false)
        {
            Debug.Log($"해당키에 저장된 값이 없습니다. : {typeof(T).Name}");
            return null;
        }

        return objects[index] as T;
    }

    protected GameObject GetGameObject(int index) => Get<GameObject>(index);
    protected Button GetButton(int index) => Get<Button>(index);
    protected Text GetText(int index) => Get<Text>(index);
}
