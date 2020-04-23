using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingColliderDoer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(7.68f, 0.4f);
        GetComponent<BoxCollider2D>().offset = new Vector2(0, 1.72f);
    }
}
