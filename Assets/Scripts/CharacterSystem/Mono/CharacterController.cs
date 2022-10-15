using UnityEngine;

[RequireComponent(typeof(ICanMove2D))]
[RequireComponent(typeof(IDamagableThatHaveHealth))]
[RequireComponent(typeof(IHaveWeapon))]
public abstract class CharacterController : MonoBehaviour
{
    [SerializeField] float movementSpeed=50;
    protected IHaveCharacterMovementInput iHaveCharacterMovementInput;
    ICanMove2D iCanMove;
    protected IDamagableThatHaveHealth iDamagableThatHaveHealth;
    protected IHaveWeapon iHaveWeapon;


    protected virtual void Awake()
    {
        iCanMove = GetComponent<ICanMove2D>();
        iHaveWeapon = GetComponent<IHaveWeapon>();
        iDamagableThatHaveHealth = GetComponent<IDamagableThatHaveHealth>();
    }

    protected virtual void OnEnable()
    {
        iHaveCharacterMovementInput.OnMoveLeftInput.Event = () => iCanMove.MoveLeft(movementSpeed);
        iHaveCharacterMovementInput.OnMoveRightInput.Event = () => iCanMove.MoveRight(movementSpeed);
        iHaveCharacterMovementInput.OnMoveBackwardInput.Event = () => iCanMove.MoveBackward(movementSpeed);
        iHaveCharacterMovementInput.OnMoveForwardInput.Event = () => iCanMove.MoveForward(movementSpeed);
        iDamagableThatHaveHealth.OnHealthBelowZero = OnDead;
    }

    protected virtual void OnDisable()
    {
        iHaveCharacterMovementInput.OnMoveLeftInput = null;
        iHaveCharacterMovementInput.OnMoveRightInput = null;
        iHaveCharacterMovementInput.OnMoveBackwardInput = null;
        iHaveCharacterMovementInput.OnMoveForwardInput = null;
    }

    protected abstract void OnDead();

}
