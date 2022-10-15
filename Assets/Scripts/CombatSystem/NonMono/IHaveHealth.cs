using System;

public interface IHaveHealth
{
    float CurrentHealth { get; }
    float MaxHealth { get; }
    Action OnHealthUpdated { get; set; }
    Action OnHealthBelowZero { get; set; }
}

