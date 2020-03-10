using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    Text myText;

    public void Embiggen(Transform myObject)
    {
        Debug.Log("Mouse Entered!");
        myObject.transform.localScale += new Vector3(0.1F, 0, 0);
        myText = myObject.GetComponentInChildren<Text>();
        TextWhite();
    }

    public void Smally(Transform myObject)
    {
        Debug.Log("Mouse Exit!");
        myObject.transform.localScale -= new Vector3(0.1F, 0, 0);
        myText = myObject.GetComponentInChildren<Text>();
        TextBlack();
    }

    void TextWhite()
    {
        myText.color = Color.white;
    }

    void TextBlack()
    {
        myText.color = Color.black;
    }
}
