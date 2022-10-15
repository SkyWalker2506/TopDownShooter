using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableMovementInput ")]
public class ScriptableMovementInput : ScriptableObject, IHaveCharacterMovementInput
{
    EventBase onMoveLeftInput{ get; set; }
    EventBase onMoveRightInput { get; set; }
    EventBase onMoveBackwardInput { get; set; }
    EventBase onMoveForwardInput { get; set; }

    public IEvent OnMoveLeftInput { get=> onMoveLeftInput; set=> onMoveLeftInput=(EventBase)value; } 
    public IEvent OnMoveRightInput { get => onMoveRightInput; set => onMoveRightInput = (EventBase)value; }
    public IEvent OnMoveBackwardInput { get => onMoveBackwardInput; set => onMoveBackwardInput = (EventBase)value; }
    public IEvent OnMoveForwardInput { get => onMoveForwardInput; set => onMoveForwardInput = (EventBase)value; } 

}