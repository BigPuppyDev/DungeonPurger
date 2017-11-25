using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : WeaponHandler
{
    override protected void Attack()
    {
        FireBullet();
    }

    private void FireBullet()
    {
    }
}