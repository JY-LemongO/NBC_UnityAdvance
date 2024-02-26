using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBase : Parts
{
    [field: SerializeField] public UpperPartsSO UpperSO { get; private set; }

    [field: SerializeField] public Transform VerticalPivot { get; private set; }    

    public override void Fire()
    {
        base.Fire();

    }

    public override void Look()
    {
        base.Look();

        Rotate();        
    }

    private void Rotate()
    {
        if (_playerController.MoveDirection == Vector3.zero)
            return;

        Vector3 cameraForward = Camera.main.transform.forward;

        float yRotation = Mathf.Atan2(cameraForward.x, cameraForward.z) * Mathf.Rad2Deg;
        float xRotation = Mathf.Atan2(-cameraForward.y, Mathf.Sqrt(cameraForward.x * cameraForward.x + cameraForward.z * cameraForward.z)) * Mathf.Rad2Deg;
        Quaternion targetRotY = Quaternion.Euler(0, yRotation, 0);
        Quaternion targetRotX = Quaternion.Euler(xRotation, yRotation, 0);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotY, 25 * Time.deltaTime);
        VerticalPivot.rotation = Quaternion.Slerp(VerticalPivot.rotation, targetRotX, 25 * Time.deltaTime);
    }
}
