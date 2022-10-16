using MovementSystem;
using UnityEngine;

public class JoyisticInputListener : ScriptableMovementInputListener
{
    [SerializeField]VariableJoystick variableJoystick;

    private void Update()
    {
        if (Mathf.Abs(variableJoystick.Horizontal)> variableJoystick.DeadZone)
            scriptableMovementInput.OnHorizontalMovementInput.Event?.Invoke(variableJoystick.Horizontal);
        if (Mathf.Abs(variableJoystick.Vertical) > variableJoystick.DeadZone)
            scriptableMovementInput.OnDepthMovementInput.Event?.Invoke(variableJoystick.Vertical);
        
    }
}
