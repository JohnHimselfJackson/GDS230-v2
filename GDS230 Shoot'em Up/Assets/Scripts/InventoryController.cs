using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Sprite pistolImage;
    public Sprite rifleImage;
    public GenericPlayerWeapon[] playerWeapons;
    public GameObject[] veiwWindows = new GameObject[16];
    // Start is called before the first frame update
    void Start()
    {
        playerWeapons = ConvertSaveDataToWeaponStat(SaveSystem.LoadWeaponData());
        AssignButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GenericPlayerWeapon[] ConvertSaveDataToWeaponStat(PlayerWeaponSaveData[] playerWeaponsData)
    {
        GenericPlayerWeapon[] returnList = new GenericPlayerWeapon[16];
        for (int ww = 0; ww < playerWeaponsData.Length; ww++)
        {
            returnList[ww].AssignFromSavedData(playerWeaponsData[ww]);
        }
        return returnList;
    }


    void AssignButtons()
    {
        for (int bb = 0; bb <16; bb++)
        {
            if(playerWeapons[bb] != null)
            {
                veiwWindows[bb].SetActive(true);
                switch (playerWeapons[bb].weaponType)
                {
                    case "pistol":
                        veiwWindows[bb].GetComponent<Image>().sprite = pistolImage;
                    break;
                    case "rifle":
                        veiwWindows[bb].GetComponent<Image>().sprite = rifleImage;
                    break;
                    defualt:
                        Debug.Log("weapon type is null despite the srcipt existing");
                    break;

                }
            }
            else
            {
                veiwWindows[bb].SetActive(false);
            }
        }
    }




}
