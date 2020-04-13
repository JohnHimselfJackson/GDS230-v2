using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPistol : GenericEnemyWeapon
{
    void Awake()
    {
        gunName = "Pistol";
        shotArc = 14;
        numberOfShots = 1;
        timeBetweenShots = 0;
        bulletSpeed = 80f;
        startDisplacement = -gameObject.transform.right * 0.15f;
    }
}