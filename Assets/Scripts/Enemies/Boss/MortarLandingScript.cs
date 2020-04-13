using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarLandingScript : MonoBehaviour
{
    public Sprite explosionSprite;
    public Animator explosionAnimation;
    public LayerMask unbreakable;
    public LayerMask breakable;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BecomeExplosion", 5f);
        Ground();
        BringFront();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BecomeExplosion()
    {
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

    void Ground()
    {
        RaycastHit2D hitUnbreakable = Physics2D.Raycast(transform.position, Vector2.down, 10, unbreakable);
        RaycastHit2D hitBreakable = Physics2D.Raycast(transform.position, Vector2.down, 10, breakable);

        if (hitUnbreakable && hitBreakable)
        {
            if(hitBreakable.point.y > hitUnbreakable.point.y)
            {
                transform.position = hitBreakable.point + Vector2.up * 0.25f;
            }
            else
            {
                transform.position = hitUnbreakable.point + Vector2.up * 0.25f;
            }
        }
        else if (hitUnbreakable)
        {
            transform.position = hitUnbreakable.point + Vector2.up * 0.25f;
        }
        else if (hitBreakable)
        {
            transform.position = hitBreakable.point + Vector2.up * 0.25f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void BringFront()
    {
        transform.position = transform.position - new Vector3(0, 0, 2);
    }



}
