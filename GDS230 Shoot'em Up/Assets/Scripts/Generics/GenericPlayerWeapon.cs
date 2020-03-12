using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlayerWeapon : MonoBehaviour
{
    public string weaponType;
    public float fireRate = 1;
    public float damage;
    public float projectileSpeed;
    public float projectileSizeMulti;
    public float ammoPerShot;
    public GameObject projectile;

    public Transform firePosition;

    float timeToFire = 0;

    // Update is called once per frame
    public void CallToShoot()
    {
        //Fire rate
        if (timeToFire < 0)
        {
            timeToFire = (1 / fireRate);
            Shoot();
            print("test 1");
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        print("test 2");
        GameObject newProjectile = Instantiate(projectile, firePosition.position, firePosition.rotation);
        newProjectile.GetComponent<PlayerBullet>().SetBulletValues((int)damage, projectileSpeed, projectileSizeMulti);
        //Player.Ammo - ammoPerShot;
    }
    public virtual void GenerateRandomWeaponStats(float qualityDecimal)
    {

    }
    
    public void AssignFromSavedData(PlayerWeaponSaveData data)
    {
        weaponType = data.weaponType;
        fireRate = data.fireRate;
        damage = data.damage;
        projectileSpeed = data.projectileSpeed;
        projectileSizeMulti = data.projectileSizeMulti;
        ammoPerShot = data.ammoPerShot;
    }
}
