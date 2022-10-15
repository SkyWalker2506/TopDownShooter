using System;

public interface IHaveCharacterMovementInput
{
    public IEvent OnMoveLeftInput { get; set; }
    public IEvent OnMoveRightInput { get; set; }
    public IEvent OnMoveBackwardInput { get; set; }
    public IEvent OnMoveForwardInput { get; set; }
}


