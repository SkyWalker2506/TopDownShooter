using System;

public interface IHaveCharacterMovementInput
{
    public IEvent<float> OnHorizontalMovementInput { get; set; }
    public IEvent<float> OnDepthMovementInput { get; set; }
}
