using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour {

    [SerializeField]
    private WeaponHandler currentWeapon;
    [SerializeField]
    private List<WeaponHandler> weapons = new List<WeaponHandler>();
    private int index = 0;

    public void SwitchWeapons()
    {
        index++;
        index %= weapons.Count;
        currentWeapon = weapons[index];
    }

    public void StartAttack()
    {
        if (!currentWeapon)
            return;

        currentWeapon.StartAttack();
    }

    public void StopAttack()
    {
        if (!currentWeapon)
            return;

        currentWeapon.StopAttack();
    }

    public bool IsAttacking()
    {
        return currentWeapon.IsAttacking();
    }
}
