using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamagableThatHaveHealth
{
    [SerializeField]float maxHealth=100;
    float currentHealth;
    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    public float HealthRatio => currentHealth/maxHealth;
    public Action OnHealthUpdated { get; set; }
    public Action OnHealthBelowZero { get; set; }

    private void Awake()
    {
        currentHealth = maxHealth;
        OnHealthUpdated?.Invoke();
    }

    public void OnDamaged(float value)
    {
        currentHealth -= value;
        if(currentHealth<=0)
        {
            currentHealth = 0;
            OnHealthBelowZero?.Invoke();
        }
        OnHealthUpdated?.Invoke();
    }
}
