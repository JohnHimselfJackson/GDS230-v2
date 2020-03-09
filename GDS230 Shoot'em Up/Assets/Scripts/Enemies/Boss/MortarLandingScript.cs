using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarLandingScript : MonoBehaviour
{
    public Sprite explosionSprite;
    public Animator explosionAnimation;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BecomeExplosion", 5f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BecomeExplosion()
    {;
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        GetComponent<Animator>().Play("MortarExplosionAnimation");
        Physics2D.BoxCastAll(transform.position , new Vector2(0.5f,0.5f), 0, Vector2.zero);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void CheckForPlayer(RaycastHit2D[] hits)
    {
        for (int cc = 0; cc < hits.Length; cc++)
        {
            if (hits[cc].collider.gameObject.CompareTag("Players"))
            {
                hits[cc].collider.gameObject.GetComponent<PlayerHealth>().Damage(5);
            }
        }
        
    }



}
