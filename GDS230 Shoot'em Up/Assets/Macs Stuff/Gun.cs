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
        Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
    }

    public void StartShooting()
    {
        shooting = true;
        print("Shooting Started");
    }

    public void StopShooting()
    {
        print("Shooting Started");
        shooting = false;
    }
}
