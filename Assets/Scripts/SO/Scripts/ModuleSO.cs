using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSO : ScriptableObject
{
    [field: SerializeField] public string TypeName { get; private set; }
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: TextArea]
    [field: SerializeField] public string Description {  get; private set; }

    [field: SerializeField] public int Armor { get; private set; }
    [field: SerializeField] public int Weight { get; private set; }
}
