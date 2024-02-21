using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    // To Do - 모듈SO 받기
    public LowerPartsSO _currentLowerPart;
    public UpperPartsSO _currentUpperPart;

    public GameObject _lower;
    public GameObject _upper;

    public Transform _lowerParent;
    public Transform _upperParent;

    private void Awake()
    {
        Managers.Module.OnChangeLowerParts += ChangeLowerParts;
    }

    private void FindParts()
    {
        // To Do - 현재 파츠들 찾고 SO 할당
    }

    private void ChangeLowerParts(LowerBase lowerParts)
    {
        Destroy(_lower);
        _lower = Managers.RM.Instantiate($"Parts/Leg/{lowerParts.name}", _lowerParent);
    }
}
