using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleRotator : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] float _rotateSpeed;

    private void FixedUpdate()
    {
        Vector3 rotDir = Vector3.up;
        Vector3 rotate = rotDir * _rotateSpeed * Time.fixedDeltaTime;

        transform.Rotate(rotate);
    }
}
