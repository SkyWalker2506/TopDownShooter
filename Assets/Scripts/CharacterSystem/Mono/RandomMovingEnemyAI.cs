using UnityEngine;

public class RandomMovingEnemyAI: EnemyAI
{
    float horizontalMovementValue;
    float depthMovementValue;

    void Awake()
    {
        InvokeRepeating(nameof(SetMovementValue),0,1);
    }

    void Update()
    {
        OnHorizontalMovementInput?.CallEvent(horizontalMovementValue);
        OnDepthMovementInput?.CallEvent(depthMovementValue);
    }

    void SetMovementValue()
    {
        horizontalMovementValue = Random.Range(-1f, 1f);
        depthMovementValue = Random.Range(-1f, 1f);
    }
}
