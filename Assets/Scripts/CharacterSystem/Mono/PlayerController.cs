using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    protected override void OnDead()
    {
        Debug.Log("Player Dead");
        gameObject.SetActive(false);
    }

    protected override void SetCharacterMovementInput()
    {
        iHaveCharacterMovementInput = scriptableMovementInput;
    }

    protected override void SetWeaponInput()
    {
        iHaveWeaponInput = scriptableWeaponEvent;
    }
}
