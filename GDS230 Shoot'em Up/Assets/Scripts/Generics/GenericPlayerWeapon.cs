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

    bool shooting = false;
    float timeToFire = 0;


    // Update is called once per frame
    void Update()
    {
        //Fire rate
        if (shooting &&  timeToFire> 0)
        {
            timeToFire = Time.time + (1 / fireRate);
            Shoot();
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, firePosition.position, firePosition.rotation);
        newProjectile.GetComponent<PlayerBullet>().SetBulletValues((int)damage, projectileSpeed, projectileSizeMulti);
        //Player.Ammo - ammoPerShot;
    }

    public void StartShooting()
    {
        shooting = true;
    }

    public void StopShooting()
    {
        shooting = false;
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
