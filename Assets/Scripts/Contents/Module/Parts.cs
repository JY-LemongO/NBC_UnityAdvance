using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour, ILowerParts
{
    protected Module _module;

    public virtual void Fire() { }

    public virtual void Look() { } 

    public virtual void Move() { } 
}
