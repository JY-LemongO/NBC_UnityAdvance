using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager
{
    // To Do - Dictionary 또는 특정 자료구조에 파츠를 저장하고 있을 것, 해금 또는 불러오기용
    private Dictionary<string, Parts[]> _parts = new Dictionary<string, Parts[]>();

    public Action<LowerBase> OnChangeLowerParts;
    public Action<string, UpperBase> OnChangeUpperParts;

    public LowerBase CurrentLowerParts { get; private set; }
    public UpperBase CurrentUpperParts { get; private set; }

    private int currentLowerIndex = 0;
    private int currentUpperIndex = 0;

    // 게임 시작 시 현재 가지고있는 파츠들 딕셔너리에 담아놓기
    public void Init()
    {
        Parts[] lowerParts = Resources.LoadAll<LowerBase>("Prefabs/Parts/Leg");
        Parts[] upperParts = Resources.LoadAll<UpperBase>("Prefabs/Parts/Weapon");
        _parts.Add("Leg", lowerParts);
        _parts.Add("Weapon", upperParts);
    }

    // 하체 변경
    public void ChangeLowerParts(int index)
    {
        Parts[] parts;
        if(_parts.TryGetValue("Leg", out parts) == false) 
        {
            Debug.Log("저장된 Lower 파츠가 없습니다.");
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

    // 상체 변경
    public void ChangeUpperParts<T>(int index = 0, string name = null) where T : IUpperParts
    {
        if(string.IsNullOrEmpty(name))
        name = typeof(T).Name;

        Managers.RM.Instantiate($"Parts/Weapon/{name}");

        
    }
}
