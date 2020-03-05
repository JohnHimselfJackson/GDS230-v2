using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRifle : GenericEnemyWeapon
{
    void Awake()
    {
        gunName = "Rifle";
        shotArc = 22;
        numberOfShots = 3;
        timeBetweenShots = 0.15f;
        bulletSpeed = 90f;
        startDisplacement = -gameObject.transform.right * 0.15f;
    }
}
