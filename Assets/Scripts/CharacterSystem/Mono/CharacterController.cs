using CombatSystem;
using EventSystem;
using MovementSystem;
using UnityEngine;

namespace CharacterSystem
{
    [RequireComponent(typeof(ICanMove2D))]
    [RequireComponent(typeof(IDamagableThatHaveHealth))]
    [RequireComponent(typeof(IHaveWeapon))]
    public abstract class CharacterController : MonoBehaviour
    {
        [SerializeField] float movementSpeed=5;
        protected IHaveCharacterMovementInput iHaveCharacterMovementInput;
        protected IHaveWeaponInput iHaveWeaponInput;
        ICanMove2D iCanMove;
        protected IDamagableThatHaveHealth iDamagableThatHaveHealth;
        protected IHaveWeapon iHaveWeapon;

        protected virtual void Awake()
        {
            iCanMove = GetComponent<ICanMove2D>();
            iHaveWeapon = GetComponent<IHaveWeapon>();
            iDamagableThatHaveHealth = GetComponent<IDamagableThatHaveHealth>();
            SetCharacterMovementInput();
            SetWeaponInput();
        }

        protected virtual void OnEnable()
        {
            iHaveCharacterMovementInput.OnHorizontalMovementInput.Event = (x) => iCanMove.MoveHorizontal(x*movementSpeed);
            iHaveCharacterMovementInput.OnDepthMovementInput.Event = (x) => iCanMove.MoveDepth(x*movementSpeed);
            iHaveWeaponInput.AttackAction.Event = iHaveWeapon.Attack;
            iHaveWeaponInput.AttackStoppedEvent.Event = iHaveWeapon.StopAttack;
            iDamagableThatHaveHealth.OnHealthBelowZero = OnDead;
        }

        protected virtual void OnDisable()
        {
            iHaveCharacterMovementInput.OnHorizontalMovementInput.Event = null;
            iHaveCharacterMovementInput.OnDepthMovementInput.Event = null;
            iHaveWeaponInput.AttackAction.Event = null;
            iHaveWeaponInput.AttackStoppedEvent.Event = null;
            iDamagableThatHaveHealth.OnHealthBelowZero = null;
        }

        protected abstract void SetCharacterMovementInput();
        protected abstract void SetWeaponInput();
        protected abstract void OnDead();

    }

}