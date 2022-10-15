using UnityEngine;

public class RayWeaponBase : WeaponBase
{
    [SerializeField] ParticleSystem shotParticle;
    float weaponDamage=10;
    protected override void Shot()
    {
        shotParticle.Emit(5);
        RaycastHit hit;
        if (Physics.SphereCast(weaponTip.position,1, weaponTip.TransformDirection(Vector3.forward), out hit))
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.TryGetComponent(out IDamagable damagable))
                damagable.OnDamaged(weaponDamage);
        }
    }

}