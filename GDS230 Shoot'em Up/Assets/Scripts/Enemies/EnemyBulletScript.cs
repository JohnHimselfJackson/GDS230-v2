using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
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
            GO.GetComponent<PlayerHealth>().Damage(1);
        }
        else if(GO.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }


}
    