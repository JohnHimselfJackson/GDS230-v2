using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.CompareTag("Player"))
        {
            //damage player
        }
        Destroy(this.gameObject);
    }


}
    