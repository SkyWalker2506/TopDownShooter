using UnityEngine;
namespace CharacterSystem
{
    public class EnemyController : CharacterController
    {
        IEnemyAI enemyAI;

        protected override void Awake()
        {
            enemyAI = GetComponent<IEnemyAI>();
            base.Awake();
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

}