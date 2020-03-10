using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public PickUpData dataHolder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dataHolder.coinsPickedUp++;
        Destroy(this, 0f);
    }
}
