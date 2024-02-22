using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    // To Do - ���SO �ޱ�
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
        // ���� �� ��� ���� �� �ʱ�ȭ
        LowerBase lower = Managers.Module.CurrentLowerParts;
        UpperBase upper = Managers.Module.CurrentUpperParts;

        _lower = Instantiate(lower.gameObject, _lowerParent);
        _upperParent = Util.FindChild<Transform>(_lower, "Joint_Lower", true);

        _upper = Instantiate(upper.gameObject, _upperParent);

        _currentLowerSO = _lower.GetComponent<LowerBase>().lowerSO;
        _currentUpperSO = _upper.GetComponent<UpperBase>().upperSO;
    }
}
