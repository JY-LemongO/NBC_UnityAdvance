using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSO : ScriptableObject
{
    public string typeName;
    public string displayName;
    [TextArea]
    public string description;

    public float armor;
    public float weight;
}
