using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPickup : GenericWeaponPickup
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dataHolder.gameObject.AddComponent(typeof(PlayerPistol));
            dataHolder.bossWeapon = dataHolder.gameObject.GetComponent<PlayerPistol>();
            dataHolder.bossWeapon.GenerateRandomWeaponStats(0.6f);
            Destroy(gameObject);
        }
    }
}
