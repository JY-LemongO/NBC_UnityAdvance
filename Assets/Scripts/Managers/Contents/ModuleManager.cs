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
    public Action<LowerBase, UpperBase> OnInitModule;

    public LowerBase CurrentLowerParts { get; private set; }
    public UpperBase CurrentUpperParts { get; private set; }

    private int currentLowerIndex = 0;
    private int currentUpperIndex = 0;

    private bool _isInit = false;

    // ���� ���� �� ������ �������ִ� ������ ��ųʸ��� ��Ƴ���
    public void Init()
    {
        if(_isInit) return;
        _isInit = true;

        string[] lowerNames = Enum.GetNames(typeof(Define.LowerParts));
        string[] upperNames = Enum.GetNames(typeof(Define.UpperParts));

        Parts[] lowerParts = new Parts[lowerNames.Length];
        Parts[] upperParts = new Parts[upperNames.Length];
                
        for(int i = 0; i < lowerNames.Length; i++)
        {
            lowerParts[i] = Managers.RM.Load<LowerBase>($"Parts/Leg/{lowerNames[i]}");

            if (lowerParts[i] == null)
                Debug.Log($"�ٸ� ���� �̸��� �ùٸ��� �ʽ��ϴ�. : {lowerNames[i]}");
        }
        for (int i = 0; i < upperParts.Length; i++)
        {
            upperParts[i] = Managers.RM.Load<UpperBase>($"Parts/Weapon/{upperNames[i]}");

            if (upperParts[i] == null)
                Debug.Log($"���� ���� �̸��� �ùٸ��� �ʽ��ϴ�. : {upperNames[i]}");
        }

        _parts.Add("Leg", lowerParts);
        _parts.Add("Weapon", upperParts);

        CurrentLowerParts = lowerParts[0] as LowerBase;
        CurrentUpperParts = upperParts[0] as UpperBase;

        OnInitModule?.Invoke(CurrentLowerParts, CurrentUpperParts);
    }

    // ��ü ����
    public void ChangeLowerParts(int index)
    {
        currentLowerIndex += index;
        CurrentLowerParts = ChangeParts<LowerBase>("Leg", ref currentLowerIndex);
        
        OnChangeLowerParts?.Invoke(CurrentLowerParts);
        ChangeUpperParts();
    }

    // ��ü ����
    public void ChangeUpperParts(int index = 0)
    {        
        currentUpperIndex += index;
        CurrentUpperParts = ChangeParts<UpperBase>("Weapon", ref currentUpperIndex);

        OnChangeUpperParts?.Invoke(CurrentUpperParts);
    }

    private T ChangeParts<T>(string key, ref int index) where T : Parts
    {
        Parts[] parts;
        if (_parts.TryGetValue(key, out parts) == false)
        {
            Debug.Log("����� Upper ������ �����ϴ�.");
            return null;
        }

        if (index == parts.Length)
            index = 0;
        else if (index == -1)
            index = parts.Length - 1;

        return parts[index] as T;
    }
}
