using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpData : MonoBehaviour
{
    public int coinsPickedUp;
    public GenericPlayerWeapon bossWeapon;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }
}
