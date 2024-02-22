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
        Managers.Module.OnChangeUpperParts += ChangeUpperParts; 
    }

    private void FindParts()
    {
        // To Do - 현재 파츠들 찾고 SO 할당
    }

    private void ChangeLowerParts(LowerBase lowerParts)
    {
        Destroy(_lower);
        _lower = Managers.RM.Instantiate($"Parts/Leg/{lowerParts.name}", _lowerParent);
        _upperParent = Util.FindChild<Transform>(_lower, "Joint_Lower", true);
    }

    private void ChangeUpperParts(UpperBase upperParts)
    {
        Destroy(_upper);
        _upper = Managers.RM.Instantiate($"Parts/Weapon/{upperParts.name}", _upperParent);
    }
}
