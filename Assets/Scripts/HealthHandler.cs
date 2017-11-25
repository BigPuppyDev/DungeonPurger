using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour {

    [SerializeField]
    protected float health = 10f;

    public void TakeDamage(float damage)
    {
        health--;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
