using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHandler : WeaponHandler {

    public float knifeDamage = 10f;
    public float damageModifier = 1f;

    [SerializeField]
    private float attackSpeed = 1.5f;
    private float attackTime;
    private bool isAttacking = false;
    private BoxCollider2D knifeCollider;

    void Awake()
    {
        attackTime = Time.time;
        knifeCollider = GetComponent<BoxCollider2D>();
    }    
	
	void FixedUpdate ()
    {
        if (isAttacking)
        {
            if (attackTime <= Time.time)
            {
                isAttacking = false;
            }            
        }
    }

    override public void StartAttack()
    {
        if (!isAttacking)
        {
            attackTime = Time.time + attackSpeed;
            isAttacking = true;
            Collider2D[] colliders = Physics2D.OverlapBoxAll((Vector2)transform.position, knifeCollider.size, transform.rotation.eulerAngles.z);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] == null || colliders[i] == knifeCollider)
                    continue;

                Debug.Log(colliders[i].gameObject.name);
                HealthHandler healthHandler = colliders[i].GetComponent<HealthHandler>();
                if(healthHandler)
                {
                    healthHandler.TakeDamage(knifeDamage);
                }
            }
        }
    }
    
    public override bool IsAttacking()
    {
        return isAttacking;
    }

    public override void StopAttack()
    {
    }        
}
