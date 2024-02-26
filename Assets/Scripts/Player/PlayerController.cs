using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Module Module {  get; private set; }
    public CinemachineVirtualCamera VirtualCamera { get; private set; }

    public PlayerInputActions Input { get; private set; }
    public PlayerInputActions.PlayerActions Actions { get; private set; }

    public LowerBase LowerBase { get; private set; }
    public UpperBase UpperBase { get; private set; }    

    public Rigidbody Rigidbody { get; private set; }

    public Vector3 MoveDirection { get; set; }

    public void Init(Module module)
    {
        Module = module;

        VirtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        VirtualCamera.Follow = Module.CamFollower;
        VirtualCamera.LookAt = module.CamFollower;

        Input = new PlayerInputActions();
        Input.Enable();
        Actions = Input.Player;

        LowerBase = Module.Lower.GetComponent<LowerBase>();
        UpperBase = Module.Upper.GetComponent<UpperBase>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpperBase?.Look();
        UpperBase?.Fire();
        LowerBase?.HandleInput();
    }

    private void FixedUpdate()
    {
        LowerBase?.Move();
    }
}
