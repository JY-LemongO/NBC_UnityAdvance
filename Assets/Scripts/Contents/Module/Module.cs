using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    [field: SerializeField] public LowerPartsSO CurrentLowerSO { get; private set; }
    [field: SerializeField] public UpperPartsSO CurrentUpperSO { get; private set; }

    [field: SerializeField] public LowerBase Lower { get; private set; }
    [field: SerializeField] public UpperBase Upper { get; private set; }

    [field: SerializeField] public Transform LowerParent { get; private set; }
    [field: SerializeField] public Transform UpperParent { get; private set; }
    [field: SerializeField] public Transform CamFollower { get; private set; }

    public PlayerController Controller { get; private set; }

    public int TotalArmor { get; private set; }

    private void Awake()
    {
        InitModule();
    }

    private void InitModule()
    {
        if (LowerParent == null)
            LowerParent = Util.FindChild<Transform>(gameObject, "Lower", true);
        if (UpperParent == null)
            UpperParent = Util.FindChild<Transform>(gameObject, "Upper", true);
        if (CamFollower == null)
            CamFollower = Util.FindChild<Transform>(gameObject, "CamFollower", true);

        LowerBase lower = Managers.Module.CurrentLowerParts;
        UpperBase upper = Managers.Module.CurrentUpperParts;

        Lower = Instantiate(lower.gameObject, LowerParent).GetComponent<LowerBase>();
        UpperParent.position = Util.FindChild<Transform>(Lower.gameObject, "Joint", true).transform.localPosition;
        CamFollower.position = Util.FindChild<Transform>(gameObject, "CamFollower", true).transform.localPosition + Vector3.up * 3;
        Upper = Instantiate(upper.gameObject, UpperParent).GetComponent<UpperBase>();

        CurrentLowerSO = Lower.LowerSO;
        CurrentUpperSO = Upper.UpperSO;

        TotalArmor = CurrentLowerSO.Armor + CurrentUpperSO.Armor;

        Controller = GetComponent<PlayerController>();
        Controller.Init(this);

        Lower.Init(this);
        Upper.Init(this);
    }
}
