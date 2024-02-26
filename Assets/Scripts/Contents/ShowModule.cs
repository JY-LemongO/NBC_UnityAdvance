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
        if (_lowerParent == null)
            _lowerParent = Util.FindChild<Transform>(gameObject, "Lower", true);
        if (_upperParent == null)
            _upperParent = Util.FindChild<Transform>(gameObject, "Upper", true);

        _lower = Instantiate(lowerParts.gameObject, _lowerParent);

        _upperParent.localPosition = Util.FindChild<Transform>(_lower.gameObject, "Joint", true).localPosition;
        _upper = Instantiate(upperParts.gameObject, _upperParent);
    }

    private void ChangeLowerParts(LowerBase lowerParts)
    {
        Destroy(_lower);
        _lower = Instantiate(lowerParts.gameObject, _lowerParent); 
        
        _upperParent.localPosition = Util.FindChild<Transform>(_lower.gameObject, "Joint", true).localPosition;
    }

    private void ChangeUpperParts(UpperBase upperParts)
    {
        Destroy(_upper);
        _upper = Instantiate(upperParts.gameObject, _upperParent);        
    }
}
