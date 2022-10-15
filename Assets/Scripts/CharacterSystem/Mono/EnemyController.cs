using UnityEngine;

public class EnemyController : CharacterController
{
    IEnemyAI enemyAI;
    [SerializeField] ScriptableEvent shotAction;
    [SerializeField] ScriptableEvent shotStoppedAction;
    [SerializeField] ScriptableEvent swapAction;
    IHaveMultipleWeapon iHaveMultipleWeapon => (WeaponController)iHaveWeapon;
    protected override void Awake()
    {
        base.Awake();
        enemyAI = GetComponent<IEnemyAI>();

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        enemyAI.AttackAction.Event = iHaveMultipleWeapon.Attack;
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

    protected override void SetCharacterMovementInput()
    {
        iHaveCharacterMovementInput = enemyAI;
    }

    protected override void SetWeaponInput()
    {
        iHaveWeaponInput = enemyAI;
    }
}

