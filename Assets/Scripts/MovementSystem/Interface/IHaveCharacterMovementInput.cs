using EventSystem;

namespace MovementSystem
{ 
    public interface IHaveCharacterMovementInput
    {
        public IEvent<float> OnHorizontalMovementInput { get; set; }
        public IEvent<float> OnDepthMovementInput { get; set; }
    }
}