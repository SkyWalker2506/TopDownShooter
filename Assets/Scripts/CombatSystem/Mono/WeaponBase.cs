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
            if (AttackInputType == AttackInputType.Hold)
            {
                InvokeRepeating(nameof(Shot), 0,fireInterval);
            }
            else
            {
                Invoke(nameof(SetReadyToShot), fireInterval);
                Shot();
            }
        }

    }

    public virtual void StopAttack()
    {
        CancelInvoke(nameof(Shot));
        Invoke(nameof(SetReadyToShot), fireInterval);
    }


    protected abstract void Shot();
    
    void SetReadyToShot()
    {
        readyToShot = true;
    }

}
