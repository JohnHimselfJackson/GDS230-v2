using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponHighlightedManager : MonoBehaviour
{
    public InventoryController iC;
    public PostGameDataLoader pgdl;

    public Image weaponImage;
    public TMP_Text weaponTypeTB;
    public TMP_Text weaponStatsTB;

    public Button keepBtn;
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

    public void ShowSelectedWeapon(int weaponReference)
    {
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
        keepBtn.gameObject.SetActive(false);
        discardBtn.gameObject.SetActive(true);
        discardBtn.gameObject.GetComponentInChildren<TMP_Text>().text = "Discard";

    }
    public void ShowSelectedWeapon(GenericPlayerWeapon playerweapon)
    {
        gameObject.SetActive(true);
        print("yeah good");
        switch (playerweapon.weaponType)
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
        weaponTypeTB.text = playerweapon.weaponType;
        weaponStatsTB.text = "FireRate = " + playerweapon.fireRate + "\n" +
                             "Damage = " + playerweapon.damage + "\n" +
                             "Projecticle Speed = " + playerweapon.projectileSpeed + "\n" +
                             "Projectile Size = " + playerweapon.projectileSizeMulti + "\n" +
                             "Ammo Per Shot = " + playerweapon.ammoPerShot;
        if (iC.FindNumberOfWeapons() < 16)
        {
            keepBtn.interactable = true;
        }
        else
        {
            keepBtn.interactable = false;
        }
        keepBtn.gameObject.GetComponentInChildren<TMP_Text>().text = "Keep";
        keepBtn.gameObject.SetActive(true);
        if(iC.FindNumberOfWeapons() > 2)
        {
            keepBtn.interactable = true;
        }
        else
        {
            keepBtn.interactable = false;
        }
        discardBtn.gameObject.SetActive(true);
        discardBtn.gameObject.GetComponentInChildren<TMP_Text>().text = "Discard";
    }

    public void KeepButtonPress()
    {
        int nullWeaponReference;
        if (iC.FindNumberOfWeapons() < 16)
        {
            nullWeaponReference = iC.FindNextNullWeapon();
            print(nullWeaponReference);
            print(iC.playerWeapons[nullWeaponReference]);
            print(pgdl.gameData.bossWeapon);
            //print(new PlayerWeaponSaveData(pgdl.gameData.bossWeapon));
            iC.playerWeapons[nullWeaponReference] = new PlayerWeaponSaveData(pgdl.gameData.bossWeapon);
            iC.AssignButtons();
            keepBtn.gameObject.SetActive(false);
            pgdl.weaponNameTB.text = null;
            pgdl.weaponButton.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
    public void DiscardButtonPress()
    {
        int nullWeaponReference;
        if (iC.FindNumberOfWeapons() < 16)
        {
            nullWeaponReference = iC.FindNextNullWeapon();
            print(nullWeaponReference);
            print(iC.playerWeapons[nullWeaponReference]);
            print(pgdl.gameData.bossWeapon);
            //print(new PlayerWeaponSaveData(pgdl.gameData.bossWeapon));
            iC.playerWeapons[nullWeaponReference] = new PlayerWeaponSaveData(pgdl.gameData.bossWeapon);
            iC.AssignButtons();
            keepBtn.gameObject.SetActive(false);
            pgdl.weaponNameTB.text = null;
            pgdl.weaponButton.gameObject.SetActive(false);
        }
    }




}
