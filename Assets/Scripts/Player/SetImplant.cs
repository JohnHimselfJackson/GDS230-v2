using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetImplant : MonoBehaviour
{

    public static int dash;
    public static int shield;

    void Start()
    {
        CheckPrefs();
    }

    void CheckPrefs()
    {
        dash = PlayerPrefs.GetInt("Dash");
        shield = PlayerPrefs.GetInt("Shield");
        Debug.Log("Dash is " + dash);
        Debug.Log("Shield is " + shield);
    }

    public void SetDash()
    {
        PlayerPrefs.SetInt("Dash", 1);
        PlayerPrefs.SetInt("Shield", 0);
        Debug.Log("Dash is " + dash);
        Debug.Log("Shield is " + shield);
    }

    public void SetShield()
    {
        PlayerPrefs.SetInt("Shield", 1);
        PlayerPrefs.SetInt("Dash", 0);
        Debug.Log("Dash is " + dash);
        Debug.Log("Shield is " + shield);
    }
}
