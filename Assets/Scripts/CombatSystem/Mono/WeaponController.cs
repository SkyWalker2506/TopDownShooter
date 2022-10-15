using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour, IHaveMultipleWeapon
{
    public WeaponBase Weapon => weapons[currentWeaponIndex];

    [SerializeField] List<WeaponBase> weaponPrefabs;
    List<WeaponBase> weapons;
    [SerializeField] Transform weaponHolder;
    
    int currentWeaponIndex;

    private void Awake()
    {
        CreateWeapons();
        Weapon.gameObject.SetActive(true);
    }

    void CreateWeapons()
    {
        weapons = new List<WeaponBase>();
        foreach (var weaponPrefab in weaponPrefabs)
        {
            var weapon = Instantiate(weaponPrefab,weaponHolder);
            weapon.gameObject.SetActive(false);
            weapons.Add(weapon);
        }
    }
    
    public void Attack()
    {
        if (weapons.Count > 0)
            Weapon.Attack();
    }

    public void Swap()
    {
        if (weapons.Count > 0)
        {
            Weapon.gameObject.SetActive(false);
            currentWeaponIndex++;
            currentWeaponIndex %= weapons.Count;
            Weapon.gameObject.SetActive(true);
        }
    }

    public void StopAttack()
    {
        if (weapons.Count > 0)
            Weapon.StopAttack();
    }
}