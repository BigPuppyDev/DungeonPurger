using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour {

    [SerializeField]
    private WeaponHandler currentWeapon;
    [SerializeField]
    private List<WeaponHandler> weapons = new List<WeaponHandler>();
    private int index = 0;
    private float switchTime = 0f;
    [SerializeField]
    private float switchCooldown = 0.1f;

    private void Awake()
    {
        switchTime = Time.time;
    }

    public void SwitchWeapons(Animator animator)
    {
        if (Time.time >= switchTime + switchCooldown)
        {
            index++;
            index %= weapons.Count;
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[index];
            currentWeapon.gameObject.SetActive(true);
            switchTime = Time.time;
            animator.runtimeAnimatorController = currentWeapon.GetAnimator();            
            return;
        }
        return;
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
