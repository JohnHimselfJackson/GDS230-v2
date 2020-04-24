using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    public GameObject[] mycosmetics;
    public Transform target;

    public int lootDropChance;
    public int dropRoll;

    void CalculateDrop()
    {
        dropRoll = Random.Range(0, 100);
        Debug.Log(lootDropChance);
        if (dropRoll <= lootDropChance)
        {
            CalculateItem();
        }
    }

    void CalculateItem()
    {
        int e = Random.Range(0, mycosmetics.Length - 1);
        Instantiate(mycosmetics[e], target);
    }
}
