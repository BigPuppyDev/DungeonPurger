using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponHandler : MonoBehaviour
{
    public abstract void StartAttack();
    public abstract void StopAttack();
    public abstract bool IsAttacking();
}
