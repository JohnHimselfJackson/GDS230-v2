using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryController : MonoBehaviour
{
    public int equipedWeaponReference;
    public SelectionManagerLink highlightedManager;
    public Sprite pistolImage;
    public Sprite rifleImage;
    public PlayerWeaponSaveData[] playerWeapons;
    public GameObject[] veiwWindows = new GameObject[16];
    // Start is called before the first frame update
    void Start()
    {
        playerWeapons = SaveSystem.LoadWeaponData();
        equipedWeaponReference = PlayerPrefs.GetInt("selectedWeapon", FindFirstWeapon());
        if (playerWeapons == null)
        {
            playerWeapons = new PlayerWeaponSaveData[16];
        }
        AssignButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GenericPlayerWeapon[] ConvertSaveDataToWeaponStat(PlayerWeaponSaveData[] playerWeaponsData)
    {
        GenericPlayerWeapon[] returnList = new GenericPlayerWeapon[16];
        if (playerWeaponsData != null)
        {
            for (int ww = 0; ww < playerWeaponsData.Length; ww++)
            {
                returnList[ww].AssignFromSavedData(playerWeaponsData[ww]);
            }

        }
        return returnList;
    }


    public void AssignButtons()
    {
        if (!CheckWeapon(equipedWeaponReference))
        {
            equipedWeaponReference = FindFirstWeapon();
            PlayerPrefs.SetInt("selectedWeapon", equipedWeaponReference);
        }


        for (int bb = 0; bb <16; bb++)
        {
            if(playerWeapons[bb] != null)
            {
                if(playerWeapons[bb].fireRate != 0)
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
                    if(equipedWeaponReference == bb)
                    {
                        veiwWindows[bb].GetComponent<Image>().color = Color.yellow;
                    }
                    else
                    {
                        veiwWindows[bb].GetComponent<Image>().color = Color.white;

                    }
                }
                else
                {
                    veiwWindows[bb].SetActive(false);
                }
            }
            else
            {
                veiwWindows[bb].SetActive(false);
            }
        }
    }

    public int FindNumberOfWeapons()
    {
        int returnThis = 0;
        if (playerWeapons != null)
        {
            for (int ww = 0; ww < 16; ww++)
            {
                if (playerWeapons[ww] != null)
                {
                    if (playerWeapons[ww].fireRate != 0)
                    {
                        returnThis++;
                    }
                }

            }
        }
        return returnThis;
    }


    public void OnButtonPress(Button button)
    {
        int weaponNum = int.Parse(button.name.Remove(0, 5));
        highlightedManager.ShowSelectedWeapon(weaponNum);
    }

    public int FindNextNullWeapon()
    {
        for (int ww = 0; ww < 16; ww++)
        {
            if (playerWeapons[ww] != null)
            {
                if (playerWeapons[ww].fireRate == 0)
                {
                    return ww;
                }
            }
            if (playerWeapons[ww] == null)
            {
                return ww;
            }
        }
        return 17;

    }
    public int FindFirstWeapon()
    {
        for (int ww = 0; ww < 16; ww++)
        {
            if (playerWeapons[ww] != null)
            {
                if (playerWeapons[ww].fireRate != 0)
                {
                    return ww;
                }
            }
        }
        return 17;
    }

    bool CheckWeapon(int weaponNumber)
    {
            if (playerWeapons[weaponNumber] != null)
            {
                if (playerWeapons[weaponNumber].fireRate != 0)
                {
                    return true;
                }
            }        
        return false;

    }
}
