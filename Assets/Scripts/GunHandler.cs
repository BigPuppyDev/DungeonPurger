using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : WeaponHandler
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private float bulletSpeed = 50f;

    override protected void Attack()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        GameObject spawnedBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
        spawnedBullet.GetComponent<Bullet>().Init(this);
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }    
}