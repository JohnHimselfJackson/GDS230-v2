using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riflePickup : GenericWeaponPickup
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dataHolder.gameObject.AddComponent(typeof(PlayerRifle));
            dataHolder.bossWeapon = dataHolder.gameObject.GetComponent<PlayerRifle>();
            dataHolder.bossWeapon.GenerateRandomWeaponStats(0.6f);
            Destroy(gameObject);
        }
    }
}
