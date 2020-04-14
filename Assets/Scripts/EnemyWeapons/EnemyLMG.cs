using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLMG : GenericEnemyWeapon
{
    void Awake()
    {
        parentsTransform = GetComponentInParent<Transform>();
        gunName = "LMG";
        shotArc = 30;
        numberOfShots = 6;
        timeBetweenShots = 0.05f;
        bulletSpeed = 100f;
    }
}
