using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableMovementInput ")]
public class ScriptableMovementInput : ScriptableObject, IHaveCharacterMovementInput
{
    public IEvent<float> OnHorizontalMovementInput { get; set; } = new EventBase<float>();
    public IEvent<float> OnDepthMovementInput { get; set; } = new EventBase<float>();
}