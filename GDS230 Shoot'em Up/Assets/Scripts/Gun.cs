using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GenericPlayerWeapon weaponReference;

    public Transform muzzle;
    public GameObject bulletPrefab;
    public GameObject laserPrefab;
    public bool shooting;

    void Start()
    {
        weaponReference = gameObject.AddComponent<GenericPlayerWeapon>();
        PlayerWeaponSaveData[] playerWeapons = SaveSystem.LoadWeaponData();
        if(playerWeapons == null)
        {
            Destroy(gameObject.GetComponent<GenericPlayerWeapon>());
            weaponReference = gameObject.AddComponent<PlayerPistol>();
            weaponReference.GenerateRandomWeaponStats(0.5f);
        }
        else
        {
            if (PlayerPrefs.GetInt("selectedWeapon", -1) != -1)
            {
                int weaponNumber = PlayerPrefs.GetInt("selectedWeapon");

                if (playerWeapons[weaponNumber] != null)
                {
                    if (playerWeapons[weaponNumber].fireRate == 0)
                    {
                        weaponReference.AssignFromSavedData(playerWeapons[weaponNumber]);
                    }
                    else
                    {
                        AssignFirstWeapon();
                    }
                }
                else
                {
                    AssignFirstWeapon();
                }
            }
            else
            {
                AssignFirstWeapon();
            }
            if (weaponReference.fireRate == 0)
            {
                Destroy(gameObject.GetComponent<GenericPlayerWeapon>());
                weaponReference = gameObject.AddComponent<PlayerPistol>();
                weaponReference.GenerateRandomWeaponStats(0.5f);
            }
        }
        if (weaponReference.weaponType == "pistol" || weaponReference.weaponType == "rifle")
        {
            weaponReference.projectile = bulletPrefab;
        }
        weaponReference.firePosition = muzzle;
    }




    void Update()
    {
        //Fire rate
        if (shooting)
        {
            weaponReference.CallToShoot();
        }
    }

    public void StartShooting()
    {
        shooting = true;
    }

    public void StopShooting()
    {
        shooting = false;
    }

    void AssignFirstWeapon()
    {
        PlayerWeaponSaveData[] playerWeapons = SaveSystem.LoadWeaponData();
        print(playerWeapons);
        if(playerWeapons == null)
        {
        }
        else
        {
            for (int ww = 0; ww < 16; ww++)
            {
                if (playerWeapons[ww] != null)
                {
                    if (playerWeapons[ww].fireRate != 0)
                    {
                        weaponReference.AssignFromSavedData(playerWeapons[ww]);
                    }
                }
            }
        }    
    }


}
