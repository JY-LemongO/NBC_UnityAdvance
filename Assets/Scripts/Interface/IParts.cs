using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParts
{
    public void Move();
    public void Look();
    public void Fire();

    public void HandleInput();
}
