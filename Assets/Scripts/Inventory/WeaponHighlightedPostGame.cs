using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponHighlightedPostGame : SelectionManagerLink
{
    public int weaponSelected; // -1 is none, 0-15 is buttons, 16 is boss
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
        keepBtn.gameObject.SetActive(false);
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
    public override void ShowSelectedWeapon(GenericPlayerWeapon playerweapon)
    {
        weaponSelected = 16;
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
        print(iC.FindNumberOfWeapons());
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
        if(iC.FindNumberOfWeapons() > 1)
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

    public override void KeepButtonPress()
    {
        int nullWeaponReference;
        if (iC.FindNumberOfWeapons() < 16)
        {
            nullWeaponReference = iC.FindNextNullWeapon();
            print("weapon null reference " + nullWeaponReference);
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
        weaponSelected = -1;
    }
    public override void DiscardButtonPress()
    {
        if(weaponSelected == 16)
        {
            pgdl.gameData.bossWeapon = null;
            if (pgdl.gameData.GetComponent<GenericPlayerWeapon>() != null)
            {
                Destroy(pgdl.gameData.GetComponent<GenericPlayerWeapon>());
            }
            pgdl.weaponNameTB.text = null;
            pgdl.weaponButton.gameObject.SetActive(false);
        }
        else if(weaponSelected < 16 && weaponSelected > -1)
        {
            iC.playerWeapons[weaponSelected] = null;
        }
        iC.AssignButtons();
        gameObject.SetActive(false);
        weaponSelected = -1;
    }





}
