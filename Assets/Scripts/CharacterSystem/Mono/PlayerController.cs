using CombatSystem;
using MovementSystem;
using UnityEngine;


namespace CharacterSystem
{
    public class PlayerController : CharacterController
    {
        [SerializeField] ScriptableMovementInput scriptableMovementInput;
        [SerializeField] ScriptableWeaponEvent scriptableWeaponEvent;
        IHaveMultipleWeapon iHaveMultipleWeapon => (WeaponController)iHaveWeapon;

        protected override void OnEnable()
        {
            base.OnEnable();
            iHaveWeaponInput.SwapEvent.Event = iHaveMultipleWeapon.Swap;

        }

        protected override void OnDisable()
        {
            base.OnDisable();
            iHaveWeaponInput.SwapEvent.Event = null;
        }

        protected override void SetCharacterMovementInput()
        {
            iHaveCharacterMovementInput = scriptableMovementInput;
        }

        protected override void SetWeaponInput()
        {
            iHaveWeaponInput = scriptableWeaponEvent;
        }

        protected override void OnDead()
        {
            Debug.Log("Player Dead");
            gameObject.SetActive(false);
            SceneManager.Instance.LoadScene(0);
        }
    }
}