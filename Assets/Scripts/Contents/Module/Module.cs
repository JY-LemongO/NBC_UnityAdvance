using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    // To Do - ���SO �ޱ�
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
        // To Do - ���� ������ ã�� SO �Ҵ�
    }

    private void ChangeLowerParts(LowerBase lowerParts)
    {
        Destroy(_lower);
        _lower = Managers.RM.Instantiate($"Parts/Leg/{lowerParts.name}", _lowerParent);
    }
}
