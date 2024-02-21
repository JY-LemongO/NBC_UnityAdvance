using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneCameraController : MonoBehaviour
{
    public CameraStateMachine StateMachine { get; private set; }

    public bool IsChanging { get; private set; } = false;

    public Vector2 range = new Vector2(5f, 3f);
    public AnimationCurve curve;    

    private void Awake()
    {
        StateMachine = new CameraStateMachine(this);
    }

    private void Start()
    {
        StateMachine.ChangeState(StateMachine.mainState);
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }

    public void ChangeCameraLerp(Quaternion changeQuat)
    {
        StartCoroutine(CoChangeCameraRoutine(changeQuat));
    }

    private IEnumerator CoChangeCameraRoutine(Quaternion changeQuat)
    {
        IsChanging = true;
        UI_BlockerPopup blocker = Managers.UI.ShowPopupUI<UI_BlockerPopup>();

        float current = 0;
        float percent = 0;

        Quaternion startRot = transform.localRotation;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / 1f;

            transform.localRotation = Quaternion.Lerp(startRot, changeQuat, curve.Evaluate(percent));

            yield return null;
        }

        IsChanging = false;
        blocker.ClosePopup();
    }
}
