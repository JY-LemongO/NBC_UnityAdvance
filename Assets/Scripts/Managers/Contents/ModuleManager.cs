using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager
{
    // To Do - Dictionary 또는 특정 자료구조에 파츠를 저장하고 있을 것, 해금 또는 불러오기용
    private Dictionary<string, Parts[]> _parts = new Dictionary<string, Parts[]>();

    public Action<LowerBase> OnChangeLowerParts;
    public Action<UpperBase> OnChangeUpperParts;
    public Action<LowerBase, UpperBase> OnInitModule;

    public LowerBase CurrentLowerParts { get; private set; }
    public UpperBase CurrentUpperParts { get; private set; }

    private int currentLowerIndex = 0;
    private int currentUpperIndex = 0;

    private bool _isInit = false;

    // 게임 시작 시 폴더에 가지고있는 파츠들 딕셔너리에 담아놓기
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
                Debug.Log($"다리 파츠 이름이 올바르지 않습니다. : {lowerNames[i]}");
        }
        for (int i = 0; i < upperParts.Length; i++)
        {
            upperParts[i] = Managers.RM.Load<UpperBase>($"Parts/Weapon/{upperNames[i]}");

            if (upperParts[i] == null)
                Debug.Log($"무기 파츠 이름이 올바르지 않습니다. : {upperNames[i]}");
        }

        _parts.Add("Leg", lowerParts);
        _parts.Add("Weapon", upperParts);

        CurrentLowerParts = lowerParts[0] as LowerBase;
        CurrentUpperParts = upperParts[0] as UpperBase;

        OnInitModule?.Invoke(CurrentLowerParts, CurrentUpperParts);
    }

    // 하체 변경
    public void ChangeLowerParts(int index)
    {
        currentLowerIndex += index;
        CurrentLowerParts = ChangeParts<LowerBase>("Leg", ref currentLowerIndex);
        
        OnChangeLowerParts?.Invoke(CurrentLowerParts);
        ChangeUpperParts();
    }

    // 상체 변경
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
            Debug.Log("저장된 Upper 파츠가 없습니다.");
            return null;
        }

        if (index == parts.Length)
            index = 0;
        else if (index == -1)
            index = parts.Length - 1;

        return parts[index] as T;
    }
}
