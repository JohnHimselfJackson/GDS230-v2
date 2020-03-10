using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float speed = 15;
    public Rigidbody2D rb;
    public int damage;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        GameObject gOHit = hitInfo.gameObject;
        if (gOHit.CompareTag("Enemy"))
        {
            gOHit.GetComponent<GenericEnemy>().DealDamage(damage);
        }
        if (gOHit.CompareTag("Boss"))
        {
            gOHit.GetComponent<BossScript>().DamageBoss(damage);
        }
        Destroy(gameObject);
    }
    public void SetBulletValues(int damageToSet, float speedToSet, float scaleMultiplyer)
    {
        damage = damageToSet;
        rb.velocity = transform.right * speedToSet;
        transform.localScale = transform.localScale * scaleMultiplyer;
    }
}
