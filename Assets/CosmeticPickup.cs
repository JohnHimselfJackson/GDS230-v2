using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticPickup : MonoBehaviour
{
    public GameObject myObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindMyItem();
            Destroy(myObject);
        }
    }

    void FindMyItem()
    {
        //check for an arm
        if (myObject.tag == "ArmCosmetic")
        {
            StoreManagement.armOneSold = 1;
            Debug.Log(StoreManagement.armOneSold);
        }
    }
}
