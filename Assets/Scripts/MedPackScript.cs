using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPackScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject go = col.gameObject;
        if (go.CompareTag("Player"))
        {
            //calls fucntion for giving health
            Destroy(gameObject);
        }
    }
}
