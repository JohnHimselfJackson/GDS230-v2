using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponHighlightedInventory : SelectionManagerLink
{
    public int weaponSelected; // -1 is none, 0-15 is buttons
    public InventoryController iC;

    public Image weaponImage;
    public TMP_Text weaponTypeTB;
    public TMP_Text weaponStatsTB;

    public Button equipBtn;
    public Button discardBtn;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ShowSelectedWeapon(int weaponReference)
    {
        weaponSelected = weaponReference;
        gameObject.SetActive(true);
        switch (iC.playerWeapons[weaponReference].weaponType)
        {
            case "pistol":
                weaponImage.sprite = iC.pistolImage;
                break;
            case "rifle":
                weaponImage.sprite = iC.rifleImage;
                break;
                defualt:
                Debug.Log("weapon type is null despite the srcipt existing");
                break;
        }
        weaponTypeTB.text = iC.playerWeapons[weaponReference].weaponType;
        weaponStatsTB.text = "FireRate = " + iC.playerWeapons[weaponReference].fireRate + "\n" +
                             "Damage = " + iC.playerWeapons[weaponReference].damage + "\n" +
                             "Projecticle Speed = " + iC.playerWeapons[weaponReference].projectileSpeed + "\n" +
                             "Projectile Size = " + iC.playerWeapons[weaponReference].projectileSizeMulti + "\n" +
                             "Ammo Per Shot = " + iC.playerWeapons[weaponReference].ammoPerShot;




        if (weaponReference != iC.equipedWeaponReference)
        {
            equipBtn.interactable = true;
        }
        else
        {
            equipBtn.interactable = false;
        }
        equipBtn.gameObject.GetComponentInChildren<TMP_Text>().text = "Equip";
        equipBtn.gameObject.SetActive(true);
        if (iC.FindNumberOfWeapons() > 1)
        {
            print("test");
            discardBtn.interactable = true;
        }
        else
        {
            discardBtn.interactable = false;
        }
        discardBtn.gameObject.SetActive(true);
        discardBtn.gameObject.GetComponentInChildren<TMP_Text>().text = "Discard";

    }

    public void EquipButtonPress()
    {
        iC.equipedWeaponReference = weaponSelected;
        PlayerPrefs.SetInt("selectedWeapon", weaponSelected);
        iC.AssignButtons();
    }

    public override void DiscardButtonPress()
    {
        if (weaponSelected < 16 && weaponSelected > -1)
        {
            iC.playerWeapons[weaponSelected] = null;
        }
        iC.AssignButtons();
        gameObject.SetActive(false);
        weaponSelected = -1;
    }
}
