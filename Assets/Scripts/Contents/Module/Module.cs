using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    // To Do - 모듈SO 받기
    public LowerPartsSO _currentLowerSO;
    public UpperPartsSO _currentUpperSO;

    public GameObject _lower;
    public GameObject _upper;

    public Transform _lowerParent;
    public Transform _upperParent;

    private void Awake()
    {
        InitModule();
    }

    private void InitModule()
    {
        // 실제 쓸 모듈 생성 및 초기화
        LowerBase lower = Managers.Module.CurrentLowerParts;
        UpperBase upper = Managers.Module.CurrentUpperParts;

        _lower = Instantiate(lower.gameObject, _lowerParent);
        _upperParent = Util.FindChild<Transform>(_lower, "Joint_Lower", true);

        _upper = Instantiate(upper.gameObject, _upperParent);

        _currentLowerSO = _lower.GetComponent<LowerBase>().lowerSO;
        _currentUpperSO = _upper.GetComponent<UpperBase>().upperSO;
    }
}
