using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Vector2 laserDimensions;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActivateLaser", 1f);
    }

    void ActivateLaser()
    {

    }



}
