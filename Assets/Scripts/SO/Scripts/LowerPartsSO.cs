using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Module/Lower", fileName = "Lower_")]
public class LowerPartsSO : ModuleSO
{
    // To Do - 다리에 필요한 정보
    [field: SerializeField] public float Power { get; private set; }
}
