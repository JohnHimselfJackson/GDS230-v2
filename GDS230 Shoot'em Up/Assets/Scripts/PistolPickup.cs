using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPickup : MonoBehaviour
{
    public PickUpData dataHolder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dataHolder.bossWeapon = new PlayerPistol();
        dataHolder.bossWeapon.GenerateRandomWeaponStats(0.6f);
        Destroy(this);
    }
}
