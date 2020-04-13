using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerWeaponSaveData
{
    public string weaponType;
    public float fireRate = 1;
    public float damage;
    public float projectileSpeed;
    public float projectileSizeMulti;
    public float ammoPerShot;


    public PlayerWeaponSaveData(GenericPlayerWeapon ws)
    {
        weaponType = ws.weaponType;
        fireRate = ws.fireRate;
        damage = ws.damage;
        projectileSpeed = ws.projectileSpeed;
        projectileSizeMulti = ws.projectileSizeMulti;
        ammoPerShot = ws.ammoPerShot;
    }
}
