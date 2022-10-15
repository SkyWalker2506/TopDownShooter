using UnityEngine;
using UnityEngine.EventSystems;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected Transform weaponTip;
    [SerializeField] protected float fireInterval =.1f;
    public AttackInputType AttackInputType;
    bool readyToShot=true;

    public virtual void Attack()
    {
        if(readyToShot)
        {
            readyToShot = false;
            Invoke(nameof(SetReadyToShot), fireInterval);
            if (AttackInputType == AttackInputType.Hold)
                InvokeRepeating(nameof(Shot), 0,fireInterval);
            else
                Shot();
        }

    }

    public virtual void StopAttack()
    {
        CancelInvoke(nameof(Shot));
    }


    protected abstract void Shot();
    
    void SetReadyToShot()
    {
        readyToShot = true;
    }

}
