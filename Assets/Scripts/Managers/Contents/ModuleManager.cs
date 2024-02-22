using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager
{
    // To Do - Dictionary �Ǵ� Ư�� �ڷᱸ���� ������ �����ϰ� ���� ��, �ر� �Ǵ� �ҷ������
    private Dictionary<string, Parts[]> _parts = new Dictionary<string, Parts[]>();

    public Action<LowerBase> OnChangeLowerParts;
    public Action<UpperBase> OnChangeUpperParts;

    public LowerBase CurrentLowerParts { get; private set; }
    public UpperBase CurrentUpperParts { get; private set; }

    private int currentLowerIndex = 0;
    private int currentUpperIndex = 0;

    // ���� ���� �� ������ �������ִ� ������ ��ųʸ��� ��Ƴ���
    public void Init()
    {
        Parts[] lowerParts = Resources.LoadAll<LowerBase>("Prefabs/Parts/Leg");
        Parts[] upperParts = Resources.LoadAll<UpperBase>("Prefabs/Parts/Weapon");
        _parts.Add("Leg", lowerParts);
        _parts.Add("Weapon", upperParts);

        CurrentLowerParts = lowerParts[0] as LowerBase;
        CurrentUpperParts = upperParts[0] as UpperBase;
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

        ChangeUpperParts();
    }

    // ��ü ����
    public void ChangeUpperParts(int index = 0)
    {
        Parts[] parts;
        if (_parts.TryGetValue("Weapon", out parts) == false)
        {
            Debug.Log("����� Upper ������ �����ϴ�.");
            return;
        }

        int nextIndex = currentUpperIndex + index;

        if (nextIndex == parts.Length)
            currentUpperIndex = 0;
        else if (nextIndex == -1)
            currentUpperIndex = parts.Length - 1;

        CurrentUpperParts = parts[currentUpperIndex] as UpperBase;

        OnChangeUpperParts?.Invoke(CurrentUpperParts);
    }
}
