using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Vector2 laserDimensions;
    public Sprite activeLaser;
    public bool laserActive = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActivateLaser", 1.6f);
    }

    void ActivateLaser()
    {
        sr.sprite = activeLaser;
        sr.color = Color.white;
        laserActive = true;
        Destroy(gameObject, 2f);
    }

    void OnTriggerStay2D(Collider2D inLaser)
    {
        GameObject gOHit = inLaser.GetComponent<Collider>().gameObject;
        if (laserActive)
        {
            if (gOHit.CompareTag("Player"))
            {
                gOHit.GetComponent<PlayerHealth>().Damage(Time.deltaTime * 4);
            }
        }
    }



}
