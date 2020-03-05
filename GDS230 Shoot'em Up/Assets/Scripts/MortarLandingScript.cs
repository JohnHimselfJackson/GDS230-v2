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
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
