using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    
    private GunHandler gun;

	void Start ()
    { 
      
	}

    public void Init(GunHandler gunHandler)
    {
        gun = gunHandler;
        GetComponent<Rigidbody2D>().velocity = transform.right * gunHandler.GetBulletSpeed();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger)
            return;

        GetComponent<BoxCollider2D>().enabled = false;
        gun.DamageTarget(collider);
        Destroy(gameObject, 0.01f);
    }
}
