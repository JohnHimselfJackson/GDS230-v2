using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 8f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit " + collision.gameObject.name);
        GameObject GO = collision.gameObject;
        if (GO.CompareTag("Player"))
        {
            GO.GetComponent<PlayerHealth>().Damage(2);
            Destroy(this.gameObject);
        }
        else if(GO.tag == "Enemy")
        {
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
    