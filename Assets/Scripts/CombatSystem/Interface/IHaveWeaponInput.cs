using EventSystem;

namespace CombatSystem
{
    public interface IHaveWeaponInput
    {
        IEvent AttackAction { get; set; }
        IEvent AttackStoppedEvent { get; set; }
        IEvent SwapEvent { get; set; }
    }
}
