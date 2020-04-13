using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualPlayerLaser : MonoBehaviour
{
    public int trackingNumber = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trackingNumber < 3)
        {
            trackingNumber++;
        }
        else if (trackingNumber > 3)
        {
            gameObject.SetActive(false);
        }
    }
}
