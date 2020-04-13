using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnWeaponPickup : MonoBehaviour
{
    CustomizePreferences customPrefs;
    int myIndex;
    string myString;
    GameObject[,] inven = new GameObject[4,4];

    //The list of messages for the Dropdown
    List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData>();

    void start()
    {
        customPrefs = GetComponent<CustomizePreferences>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Add to the weapon dropdown list.
        //Weapon stats set to rifle random stats.
        //Set player prefs.
        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Add to the weapon dropdown list.
            //Weapon stats set to rifle random stats.
            //Set player prefs.
        }
    }
}
