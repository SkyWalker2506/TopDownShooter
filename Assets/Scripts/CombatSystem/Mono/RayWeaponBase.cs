using UnityEngine;

namespace CombatSystem
{
    public class RayWeaponBase : WeaponBase
    {
        [SerializeField] ParticleSystem shotParticle;
        [SerializeField] float weaponDamage=10;
        protected override void Shot()
        {
            shotParticle.Emit(1);
            RaycastHit hit;
            if (Physics.SphereCast(weaponTip.position,1, weaponTip.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.collider.TryGetComponent(out IDamagable damagable))
                    damagable.OnDamaged(weaponDamage);
            }
        }

    }
}