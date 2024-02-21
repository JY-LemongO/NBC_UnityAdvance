using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine : StateMachine
{
    public TitleSceneCameraController Controller { get; }

    public MainTiltState mainState { get; }
    public ModuleTiltState moduleState { get; }

    public Vector2 Range { get; private set; }

    public CameraStateMachine(TitleSceneCameraController controller)
    {
        Controller = controller;

        mainState = new MainTiltState(this);
        moduleState = new ModuleTiltState(this);

        Range = Controller.range;
    }
}
