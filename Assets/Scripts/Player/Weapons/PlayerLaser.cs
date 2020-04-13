using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : GenericPlayerWeapon
{
    public GameObject laserPrefab;
    float baseFireRate = 3f;
    float baseDamage = 2;
    float baseProjectileSpeed = 18f;
    float baseProjectileSizeMulti = 1f;
    float baseAmmoPerShot = 0.8f;

    public void Awake()
    {
        laserPrefab = GetComponent<Gun>().laserPrefab;
        playerLaser = Instantiate<GameObject>(laserPrefab,transform);
    }

    public override void GenerateRandomWeaponStats(float qualityDecimal)
    {
        weaponType = "laser";
        fireRate = 0;
        damage = Random.Range((qualityDecimal), 4 * qualityDecimal) ;
        projectileSpeed = baseProjectileSpeed + Random.Range((-5 + 5 * qualityDecimal), 5 * qualityDecimal);
        projectileSizeMulti = baseProjectileSizeMulti + Random.Range((-0.3f + 0.3f * qualityDecimal), 0.5f * qualityDecimal);
        ammoPerShot = baseAmmoPerShot + Random.Range(-(0.29f * qualityDecimal), (-0.5f * qualityDecimal) + 1 + damage/17);
    }
}
