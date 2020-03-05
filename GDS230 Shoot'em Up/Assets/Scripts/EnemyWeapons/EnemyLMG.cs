using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLMG : GenericEnemyWeapon
{
    void Awake()
    {
        gunName = "LMG";
        shotArc = 30;
        numberOfShots = 6;
        timeBetweenShots = 0.05f;
        bulletSpeed = 100f;
        startDisplacement = -gameObject.transform.right * 0.15f;
    }
}
