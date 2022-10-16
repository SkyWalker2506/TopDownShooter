namespace CombatSystem
{
    public interface IHaveWeapon
    {
        WeaponBase Weapon { get; }
        void Attack();
        void StopAttack();
    }
}