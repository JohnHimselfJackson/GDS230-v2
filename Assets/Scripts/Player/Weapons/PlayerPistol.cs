﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPistol : GenericPlayerWeapon
{
        float baseFireRate = 1f;
        float baseDamage = 3;
        float baseProjectileSpeed = 15f;
        float baseProjectileSizeMulti = 0.8f;
        float baseAmmoPerShot = 0.3f;

    public override void GenerateRandomWeaponStats(float qualityDecimal)
    {
        weaponType = "pistol";
        fireRate = baseFireRate * (1 + Random.Range(-0.1f * (1/qualityDecimal), 2 * qualityDecimal));
        damage = baseDamage + Random.Range((-3 + 3 * qualityDecimal), 7 * qualityDecimal) ;
        projectileSpeed = baseProjectileSpeed + Random.Range((-5 + 5 * qualityDecimal), 5 * qualityDecimal);
        projectileSizeMulti = baseProjectileSizeMulti + Random.Range((-0.3f + 0.3f * qualityDecimal), 0.5f * qualityDecimal);
        ammoPerShot = baseAmmoPerShot + Random.Range(-(0.29f * qualityDecimal), (-0.5f * qualityDecimal) + 1 + damage/17);
        projectile = Resources.Load<GameObject>("Prefabs/Bullet");
    }
}
