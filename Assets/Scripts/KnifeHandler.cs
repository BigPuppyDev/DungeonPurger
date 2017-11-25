using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHandler : WeaponHandler {
        
    override protected void Attack()
    {
        DamageTargets(GetTargets());
    }

    private Collider2D[] GetTargets()
    {
        return Physics2D.OverlapBoxAll((Vector2)transform.position, weaponCollider.size, transform.rotation.eulerAngles.z);
    }
}
