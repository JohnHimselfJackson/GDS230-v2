using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetter : MonoBehaviour
{
    public GameObject[] myObjects;

    public GameObject[] myotherObjects;

    public void SetActive()
    {
        for (int i = 0; i < myObjects.Length; i++)
        {
            myObjects[i].SetActive(true);
        }
    }

    public void SetInActive()
    {
        myotherObjects[0].SetActive(false);
        myotherObjects[1].SetActive(false);
        myotherObjects[2].SetActive(false);

    }


}
