using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : CharacterController
{
    [SerializeField] ScriptableMovementInput scriptableMovementInput;
    [SerializeField] ScriptableEvent shotAction;
    [SerializeField] ScriptableEvent shotStoppedAction;
    [SerializeField] ScriptableEvent swapAction;
    IHaveMultipleWeapon iHaveMultipleWeapon => (WeaponController)iHaveWeapon;
   
    protected override void Awake()
    {
        base.Awake();
        scriptableMovementInput.OnMoveLeftInput = new EventBase();
        scriptableMovementInput.OnMoveRightInput = new EventBase();
        scriptableMovementInput.OnMoveBackwardInput = new EventBase();
        scriptableMovementInput.OnMoveForwardInput = new EventBase();
        iHaveCharacterMovementInput = scriptableMovementInput;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        shotAction.Event = iHaveMultipleWeapon.Attack;
        shotStoppedAction.Event = iHaveMultipleWeapon.StopAttack;
        swapAction.Event = iHaveMultipleWeapon.Swap;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        shotAction.Event = null;
        shotStoppedAction.Event = null;
        swapAction.Event = null;
    }

    protected override void OnDead()
    {
        Debug.Log("Player Dead");
        gameObject.SetActive(false);
    }
}
