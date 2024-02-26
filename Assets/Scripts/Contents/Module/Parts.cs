using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour, IParts
{
    [SerializeField] protected Module _module;
    [SerializeField] protected PlayerController _playerController;    

    public virtual void Init(Module module)
    {
        _module = module;
        _playerController = module.Controller;        
    }

    public virtual void Fire() { }    

    public virtual void Move() { }

    public virtual void Look() 
    {
        Rotate();
    }

    public void HandleInput()
    {
        _playerController.MoveDirection = _playerController.Actions.Move.ReadValue<Vector2>();
    }

    private void Rotate()
    {
        if (_playerController.MoveDirection == Vector3.zero)
            return;

        if(_playerController.MoveDirection.y > 0)
        {
            Vector3 dir = _playerController.MoveDirection;
            float yRotation = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            Quaternion targetRotY = Quaternion.Euler(0, yRotation, 0);
            _module.transform.rotation = Quaternion.Slerp(_module.transform.rotation, targetRotY, 25 * Time.deltaTime);
        }
        else
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            float yRotation = Mathf.Atan2(cameraForward.x, cameraForward.z) * Mathf.Rad2Deg;
            Quaternion targetRotY = Quaternion.Euler(0, yRotation, 0);
            _module.transform.rotation = Quaternion.Slerp(_module.transform.rotation, targetRotY, 25 * Time.deltaTime);
        }
         
    }
}
