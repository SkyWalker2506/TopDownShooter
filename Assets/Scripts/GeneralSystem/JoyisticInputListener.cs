using UnityEngine;

public class JoyisticInputListener : ScriptableMovementInputListener
{
    [SerializeField]VariableJoystick variableJoystick;

    private void Update()
    {
        if (variableJoystick.Horizontal > variableJoystick.DeadZone)
            scriptableMovementInput.OnMoveRightInput.Event?.Invoke();
        else if (variableJoystick.Horizontal < -variableJoystick.DeadZone)
            scriptableMovementInput.OnMoveLeftInput.Event?.Invoke();
        if (variableJoystick.Vertical > variableJoystick.DeadZone)
            scriptableMovementInput.OnMoveForwardInput.Event?.Invoke();
        else if (variableJoystick.Vertical < -variableJoystick.DeadZone)
            scriptableMovementInput.OnMoveBackwardInput.Event?.Invoke();
    }
}
