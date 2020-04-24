using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{
    public InventoryController iC;
    public void LeavePostGame()
    {
    //    Destroy(FindObjectOfType<PickUpData>().gameObject);
    //    SaveSystem.SaveWeaponData(iC.playerWeapons);
        SceneManager.LoadScene(0);
    }
    public void LeavePostInventory()
    {
    //    SaveSystem.SaveWeaponData(iC.playerWeapons);
        SceneManager.LoadScene(0);
    }
}
