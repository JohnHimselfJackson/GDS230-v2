using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponHighlightedManager : MonoBehaviour
{
    public InventoryController iC;

    public Image weaponImage;
    public TMP_Text weaponTypeTB;
    public TMP_Text weaponStatsTB;




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
        switch (iC.playerWeapons[weaponReference].weaponType)
        {
            case "pistol":
                iC.playerWeapons[weaponReference].GetComponent<Image>().sprite = iC.pistolImage;
                break;
            case "rifle":
                iC.playerWeapons[weaponReference].GetComponent<Image>().sprite = iC.rifleImage;
                break;
                defualt:
                Debug.Log("weapon type is null despite the srcipt existing");
                break;
        }
        weaponTypeTB.text = iC.playerWeapons[weaponReference].weaponType;
        weaponStatsTB.text = "FireRate = " + iC.playerWeapons[weaponReference].fireRate + "/n" +
                             "Damage = " + iC.playerWeapons[weaponReference].damage + "/n" +
                             "Projecticle Speed = " + iC.playerWeapons[weaponReference].projectileSpeed + "/n" +
                             "Projectile Size = " + iC.playerWeapons[weaponReference].projectileSizeMulti + "/n" +
                             "Ammo Per Shot = " + iC.playerWeapons[weaponReference].ammoPerShot;
    }




}
