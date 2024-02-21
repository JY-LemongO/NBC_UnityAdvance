using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager
{
    // To Do - Dictionary �Ǵ� Ư�� �ڷᱸ���� ������ �����ϰ� ���� ��, �ر� �Ǵ� �ҷ������
    private Dictionary<string, Parts[]> _parts = new Dictionary<string, Parts[]>();

    public Action<LowerBase> OnChangeLowerParts;
    public Action<string, UpperBase> OnChangeUpperParts;

    public LowerBase CurrentLowerParts { get; private set; }
    public UpperBase CurrentUpperParts { get; private set; }

    private int currentLowerIndex = 0;
    private int currentUpperIndex = 0;

    // ���� ���� �� ���� �������ִ� ������ ��ųʸ��� ��Ƴ���
    public void Init()
    {
        Parts[] lowerParts = Resources.LoadAll<LowerBase>("Prefabs/Parts/Leg");
        Parts[] upperParts = Resources.LoadAll<UpperBase>("Prefabs/Parts/Weapon");
        _parts.Add("Leg", lowerParts);
        _parts.Add("Weapon", upperParts);
    }

    // ��ü ����
    public void ChangeLowerParts(int index)
    {
        Parts[] parts;
        if(_parts.TryGetValue("Leg", out parts) == false) 
        {
            Debug.Log("����� Lower ������ �����ϴ�.");
            return;
        }

        int nextIndex = currentLowerIndex + index;

        if (nextIndex == parts.Length)
            currentLowerIndex = 0;
        else if (nextIndex == -1)
            currentLowerIndex = parts.Length - 1;

        CurrentLowerParts = parts[currentLowerIndex] as LowerBase;

        OnChangeLowerParts?.Invoke(CurrentLowerParts);
    }

    // ��ü ����
    public void ChangeUpperParts<T>(int index = 0, string name = null) where T : IUpperParts
    {
        if(string.IsNullOrEmpty(name))
        name = typeof(T).Name;

        Managers.RM.Instantiate($"Parts/Weapon/{name}");

        
    }
}
