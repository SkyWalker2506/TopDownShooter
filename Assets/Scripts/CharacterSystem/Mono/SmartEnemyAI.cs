using UnityEngine;

namespace CharacterSystem
{
    public class SmartEnemyAI : EnemyAI
    {
        Transform player;
        Vector3 distanceVector => player.position - transform.position;
        float attackDistance=5;
        bool isAttacked;

        private void Awake()
        {
            player = FindObjectOfType<PlayerController>().transform;    
        }

        private void Update()
        {
            if (!player) return;
            if (!player.gameObject.activeSelf) return;
            if (!IsCloseEnoughToAttack())
            {
                if(isAttacked)
                {
                    AttackStoppedEvent.CallEvent();
                }
                MoveTowardsPlayer();
            }
            else
            {
                Attack();
            }

        }

        void MoveTowardsPlayer()
        {
            var direction = distanceVector.normalized;
                OnHorizontalMovementInput?.CallEvent(direction.x);
            OnDepthMovementInput?.CallEvent(direction.z);
        }

        bool IsCloseEnoughToAttack()
        {
            return distanceVector.magnitude <= attackDistance;
        }

        void Attack()
        {
            transform.LookAt(transform.position+distanceVector);
            AttackAction.CallEvent();
            isAttacked = true;
        }
    }
}