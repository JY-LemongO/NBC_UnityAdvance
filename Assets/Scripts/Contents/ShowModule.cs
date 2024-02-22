using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModule : MonoBehaviour
{
    public GameObject _lower;
    public GameObject _upper;

    public Transform _lowerParent;
    public Transform _upperParent;

    private void Awake()
    {
        Managers.Module.OnInitModule += InitModule;
        Managers.Module.OnChangeLowerParts += ChangeLowerParts;
        Managers.Module.OnChangeUpperParts += ChangeUpperParts;        
    }

    private void InitModule(LowerBase lowerParts, UpperBase upperParts)
    {
        _lower = Instantiate(lowerParts.gameObject, _lowerParent);
        _upperParent = Util.FindChild<Transform>(_lower, "Joint_Lower", true);

        _upper = Instantiate(upperParts.gameObject, _upperParent);
    }

    private void ChangeLowerParts(LowerBase lowerParts)
    {
        Destroy(_lower);
        _lower = Instantiate(lowerParts.gameObject, _lowerParent);        
        _upperParent = Util.FindChild<Transform>(_lower, "Joint_Lower", true);
    }

    private void ChangeUpperParts(UpperBase upperParts)
    {
        Destroy(_upper);
        _upper = Instantiate(upperParts.gameObject, _upperParent);        
    }
}
