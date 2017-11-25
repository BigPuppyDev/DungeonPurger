using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : WeaponHandler
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    private float bulletSpeed = 4f;    

    override protected void Attack()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
        Vector2 bulletVelocity = new Vector2(transform.right.x * bulletSpeed, transform.right.y * bulletSpeed);
        Debug.Log("BULLET SPEED " + bulletVelocity);

        firedBullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity;
    }
}