using UnityEngine;

public class SmartEnemyAI : EnemyAI
{
    Transform player;
    Vector3 distanceVector => player.position - transform.position;
    float attackDistance=5;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;    
    }

    private void Update()
    {
        if (!IsCloseEnoughToAttack())
            MoveTowardsPlayer();
        else
            Attack();

    }

    void MoveTowardsPlayer()
    {
        if (!player) return;
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
    }
}