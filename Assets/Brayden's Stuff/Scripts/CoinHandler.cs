using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    public StoreHelper currency;

    void Start()
    {
        currency = GetComponent<StoreHelper>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        StoreHelper.ZELAmount += 100;
        Destroy(gameObject);
    }
}
