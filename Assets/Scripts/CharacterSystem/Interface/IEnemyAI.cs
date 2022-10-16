using CombatSystem;
using MovementSystem;

namespace CharacterSystem
{
    public interface IEnemyAI : IHaveCharacterMovementInput, IHaveWeaponInput
    {
    }
}