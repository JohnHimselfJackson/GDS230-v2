using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    private float nextFire;

    public Transform muzzle;
    public GameObject bulletPrefab;
    public bool shooting;

    void Update()
    {
        //Fire rate
        if (shooting && Time.time > nextFire)
        {
            nextFire = Time.time + (1 / fireRate);
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet =  Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        bullet.GetComponent<PlayerBullet>().SetBulletValues(3, 20, 1);
    }

    public void StartShooting()
    {
        shooting = true;
    }

    public void StopShooting()
    {
        shooting = false;
    }
}
