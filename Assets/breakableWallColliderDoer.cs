using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableWallColliderDoer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 spriteSize = GetComponent<SpriteRenderer>().size;
        GetComponent<BoxCollider2D>().size = spriteSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
