using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    protected float weaponDamage = 10f;

    [SerializeField]
    protected float attackSpeed = 1.5f;
    protected float attackTime;
    protected bool isAttacking = false;
    protected BoxCollider2D weaponCollider;
    private AudioSource audioSource;

    [SerializeField]
    private RuntimeAnimatorController weaponAnimator;

    void Awake()
    {
        attackTime = Time.time;
        weaponCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        isAttacking = (isAttacking && attackTime <= Time.time) ? false : isAttacking;
    }

    public void DamageTargets(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            DamageTarget(colliders[i]);
        }
    }

    public void DamageTarget(Collider2D collider)
    {
        if (collider == null || collider == weaponCollider)
            return;
        
        HealthHandler healthHandler = collider.GetComponent<HealthHandler>();
        if (!healthHandler)
            return;

        healthHandler.TakeDamage(weaponDamage);
    }

    public void StartAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            attackTime = Time.time + attackSpeed;
            if(audioSource != null) 
                audioSource.Play();
            Attack();
        }
    }

    public void StopAttack()
    {

    }

    protected abstract void Attack();

    public bool IsAttacking()
    {
        return isAttacking;
    }

    public RuntimeAnimatorController GetAnimator()
    {
        return weaponAnimator;
    }
}