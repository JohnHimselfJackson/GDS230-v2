﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManagement : MonoBehaviour
{
    [System.Serializable]
    //A reference to our buttons.
    public struct StoreCosmeticButtons
    {
        public Button[] armButtons;
        public Button[] rifleButtons;
        public Button[] handgunButtons;
        public Button[] shirtButtons;
        public Button[] headsetButtons;

    }

    [System.Serializable]
    //A reference to our texts.
    public struct StoreText
    {
        public Text[] armPrice;
        public Text[] shirtPrice;
        public Text[] headSetPrice;
        public Text[] handGunPrice;
        public Text[] riflePrice;
    }

    [SerializeField]
    public StoreCosmeticButtons myCosmetics;

    [SerializeField]
    public StoreText myText;

    //Our currency and currency Text.
    public int zelAmount;
    public Text zelText;

    //The cost of our cosmetics.
    public int rifleValue;
    public int handGunvalue;
    public int characterValue;
    public int shirtValue;
    public int headSetValue;

    //Integers used for tracking what item will be sold in their array.
    public int i;
    public int e;
    public int u;
    public int a;
    public int o;

    static public int armOneSold;
    static public int armTwoSold;
    static public int armThreeSold;
    static public int armFourSold;

    static public int weaponOneSold;
    static public int weaponTwoSold;
    static public int weaponThreeSold;
    static public int weaponFourSold;

    static public int handGunOneSold;
    static public int handGunTwoSold;
    static public int handGunThreeSold;
    static public int handGunFourSold;

    static public int shirtOneSold;
    static public int shirtTwoSold;
    static public int shirtThreeSold;
    static public int shirtFourSold;

    static public int headsetOneSold;
    static public int headsetTwoSold;
    static public int headsetThreeSold;
    static public int headsetFourSold;
    //----------------------------------------------------------------

    void Start()
    {
        Debug.Log(armOneSold);
        CheckPrefs();
        Debug.Log(armOneSold);
    }

    void Update()
    {
        UpdateZELUI();
        ArmBuyValidation();
        ShirtBuyValidation();
        WeaponBuyValidation();
        HandGunBuyValidation();
        VisorBuyValidation();
    }

    //-----------------------------------------------------------------

    //Checks our store preferences.
    void UpdateZELUI()
    {
        zelText.text = "ZEL: " + zelAmount.ToString();
    }

    //Gets our player prefs.
    void CheckPrefs()
    {
        zelAmount = PlayerPrefs.GetInt("ZELAmount");
        armOneSold = PlayerPrefs.GetInt("isCharOneSold");
        armTwoSold = PlayerPrefs.GetInt("isCharTwoSold");
        armThreeSold = PlayerPrefs.GetInt("isCharThreeSold");
        armFourSold = PlayerPrefs.GetInt("isCharFourSold");

        weaponOneSold = PlayerPrefs.GetInt("isWeaponOneSold");
        weaponTwoSold = PlayerPrefs.GetInt("isWeaponTwoSold");
        weaponThreeSold = PlayerPrefs.GetInt("isWeaponThreeSold");
        weaponFourSold = PlayerPrefs.GetInt("isWeaponFourSold");

        handGunOneSold = PlayerPrefs.GetInt("ishandGunOneSold");
        handGunTwoSold = PlayerPrefs.GetInt("ishandGunTwoSold");
        handGunThreeSold = PlayerPrefs.GetInt("ishandGunThreeSold");
        handGunFourSold = PlayerPrefs.GetInt("ishandGunFourSold");

        shirtOneSold = PlayerPrefs.GetInt("isShirtOneSold");
        shirtTwoSold = PlayerPrefs.GetInt("isShirtTwoSold");
        shirtThreeSold = PlayerPrefs.GetInt("isShirtThreeSold");
        shirtFourSold = PlayerPrefs.GetInt("isShirtFourSold");

        headsetOneSold = PlayerPrefs.GetInt("isVisorOneSold");
        headsetTwoSold = PlayerPrefs.GetInt("isVisorTwoSold");
        headsetThreeSold = PlayerPrefs.GetInt("isVisorThreeSold");
        headsetFourSold = PlayerPrefs.GetInt("isVisorFourSold");
    }

    public void BuyCharacterOne()
    {
        i = 0;
        PlayerPrefs.SetInt("isCharOneSold", 1);
        BuyArm(i);
        Debug.Log(armOneSold);
    }

    public void BuyCharacterTwo()
    {
        i = 1;
        PlayerPrefs.SetInt("isCharTwoSold", 1);
        BuyArm(i);
    }

    public void BuyCharacterThree()
    {
        i = 2;
        PlayerPrefs.SetInt("isCharThreeSold", 1);
        BuyArm(i);
    }

    public void BuyCharacterFour()
    {
        i = 3;
        PlayerPrefs.SetInt("isCharFourSold", 1);
        BuyArm(i);
    }

    public void BuyArm(int i)
    {
        zelAmount -= characterValue;
        SavePrefs();
        myText.armPrice[i].text = "Sold!";
        myCosmetics.armButtons[i].gameObject.SetActive(false);
    }

    //Handles how our buttons interact by checking sold characters.
    void ArmBuyValidation()
    {
        if (zelAmount >= 1500 && armOneSold == 0)
        {
            myCosmetics.armButtons[0].interactable = true;
        }
        else
        {
            myCosmetics.armButtons[0].interactable = false;
        }

        if (zelAmount >= 1500 && armTwoSold == 0)
        {
            myCosmetics.armButtons[1].interactable = true;
        }
        else
        {
            myCosmetics.armButtons[1].interactable = false;
        }

        if (zelAmount >= 1500 && armThreeSold == 0)
        {
            myCosmetics.armButtons[2].interactable = true;
        }
        else
        {
            myCosmetics.armButtons[2].interactable = false;
        }

        if (zelAmount >= 1500 && armFourSold == 0)
        {
            myCosmetics.armButtons[3].interactable = true;
        }
        else
        {
            myCosmetics.armButtons[3].interactable = false;
        }
    }

    public void BuyShirtOne()
    {
        u = 0;
        PlayerPrefs.SetInt("isShirtOneSold", 1);
        BuyShirt(u);
    }

    public void BuyShirtTwo()
    {
        u = 1;
        PlayerPrefs.SetInt("isShirtTwoSold", 1);
        BuyShirt(u);
    }

    public void BuyShirtThree()
    {
        u = 2;
        PlayerPrefs.SetInt("isShirtThreeSold", 1);
        BuyShirt(u);
    }

    public void BuyShirtFour()
    {
        u = 3;
        PlayerPrefs.SetInt("isShirtFourSold", 1);
        BuyShirt(u);
    }

    public void BuyShirt(int u)
    {
        zelAmount -= shirtValue;
        SavePrefs();
        myText.shirtPrice[u].text = "Sold!";
        myCosmetics.shirtButtons[u].gameObject.SetActive(false);
    }

    void ShirtBuyValidation()
    {
        if (zelAmount >= 800 && shirtOneSold == 0)
        {
            myCosmetics.shirtButtons[0].interactable = true;
        }
        else
        {
            myCosmetics.shirtButtons[0].interactable = false;
        }

        if (zelAmount >= 800 && shirtTwoSold == 0)
        {
            myCosmetics.shirtButtons[1].interactable = true;
        }
        else
        {
            myCosmetics.shirtButtons[1].interactable = false;
        }

        if (zelAmount >= 800 && shirtThreeSold == 0)
        {
            myCosmetics.shirtButtons[2].interactable = true;
        }
        else
        {
            myCosmetics.shirtButtons[2].interactable = false;
        }

        if (zelAmount >= 800 && shirtFourSold == 0)
        {
            myCosmetics.shirtButtons[3].interactable = true;
        }
        else
        {
            myCosmetics.shirtButtons[3].interactable = false;
        }
    }

    public void BuyWeaponOne()
    {
        e = 0;
        PlayerPrefs.SetInt("isWeaponOneSold", 1);
        BuyWeapon(e);
    }

    public void BuyWeaponTwo()
    {
        e = 1;
        PlayerPrefs.SetInt("isWeaponTwoSold", 1);
        BuyWeapon(e);
    }

    public void BuyWeaponThree()
    {
        e = 2;
        PlayerPrefs.SetInt("isWeaponThreeSold", 1);
        BuyWeapon(e);
    }

    public void BuyWeaponFour()
    {
        e = 3;
        PlayerPrefs.SetInt("isWeaponFourSold", 1);
        BuyWeapon(e);
    }

    public void BuyWeapon(int e)
    {
        zelAmount -= rifleValue;
        SavePrefs();
        myText.riflePrice[e].text = "Sold!";
        myCosmetics.rifleButtons[e].gameObject.SetActive(false);
    }

    void WeaponBuyValidation()
    {
        if (zelAmount >= 1200 && weaponOneSold == 0)
        {
            myCosmetics.rifleButtons[0].interactable = true;
        }
        else
        {
            myCosmetics.rifleButtons[0].interactable = false;
        }

        if (zelAmount >= 1200 && weaponTwoSold == 0)
        {
            myCosmetics.rifleButtons[1].interactable = true;
        }
        else
        {
            myCosmetics.rifleButtons[1].interactable = false;
        }

        if (zelAmount >= 1200 && weaponThreeSold == 0)
        {
            myCosmetics.rifleButtons[2].interactable = true;
        }
        else
        {
            myCosmetics.rifleButtons[2].interactable = false;
        }

        if (zelAmount >= 1200 && weaponFourSold == 0)
        {
            myCosmetics.rifleButtons[3].interactable = true;
        }
        else
        {
            myCosmetics.rifleButtons[3].interactable = false;
        }
    }

    public void BuyHandGunOne()
    {
        a = 0;
        PlayerPrefs.SetInt("isVisorOneSold", 1);
        BuyVisor(a);
        Debug.Log(headsetOneSold);
    }

    public void BuyHandGunTwo()
    {
       a = 1;
        PlayerPrefs.SetInt("isVisorTwoSold", 1);
        BuyVisor(a);
    }

    public void BuyHandGunThree()
    {
        a = 2;
        PlayerPrefs.SetInt("isVisorThreeSold", 1);
        BuyVisor(a);
    }

    public void BuyHandGunFour()
    {
        a = 3;
        PlayerPrefs.SetInt("isVisorFourSold", 1);
        BuyVisor(a);
    }

    public void BuyHandGun(int a)
    {
        zelAmount -= handGunvalue;
        SavePrefs();
        myText.handGunPrice[a].text = "Sold!";
        myCosmetics.handgunButtons[a].gameObject.SetActive(false);
    }
    void HandGunBuyValidation()
    {
        if (zelAmount >= 1800 && handGunOneSold == 0)
        {
            myCosmetics.handgunButtons[0].interactable = true;
        }
        else
        {
            myCosmetics.handgunButtons[0].interactable = false;
        }

        if (zelAmount >= 1800 && handGunTwoSold == 0)
        {
            myCosmetics.handgunButtons[1].interactable = true;
        }
        else
        {
            myCosmetics.handgunButtons[1].interactable = false;
        }

        if (zelAmount >= 1800 && handGunThreeSold == 0)
        {
            myCosmetics.handgunButtons[2].interactable = true;
        }
        else
        {
            myCosmetics.handgunButtons[2].interactable = false;
        }

        if (zelAmount >= 1800 && handGunFourSold == 0)
        {
            myCosmetics.handgunButtons[3].interactable = true;
        }
        else
        {
            myCosmetics.handgunButtons[3].interactable = false;
        }
    }

    public void BuyVisorOne()
    {
        o = 0;
        PlayerPrefs.SetInt("isVisorOneSold", 1);
        BuyVisor(o);
        Debug.Log(headsetOneSold);
    }

    public void BuyVisorTwo()
    {
        o = 1;
        PlayerPrefs.SetInt("isVisorTwoSold", 1);
        BuyVisor(o);
    }

    public void BuyVisorThree()
    {
        o = 2;
        PlayerPrefs.SetInt("isVisorThreeSold", 1);
        BuyVisor(o);
    }

    public void BuyVisorFour()
    {
        o = 3;
        PlayerPrefs.SetInt("isVisorFourSold", 1);
        BuyVisor(o);
    }

    public void BuyVisor(int o)
    {
        zelAmount -= headSetValue;
        SavePrefs();
        myText.headSetPrice[o].text = "Sold!";
        myCosmetics.headsetButtons[o].gameObject.SetActive(false);
    }
    void VisorBuyValidation()
    {
        if (zelAmount >= 1800 && headsetOneSold == 0)
        {
            myCosmetics.headsetButtons[0].interactable = true;
        }
        else
        {
            myCosmetics.headsetButtons[0].interactable = false;
        }

        if (zelAmount >= 1800 && headsetTwoSold == 0)
        {
            myCosmetics.headsetButtons[1].interactable = true;
        }
        else
        {
            myCosmetics.headsetButtons[1].interactable = false;
        }

        if (zelAmount >= 1800 && headsetThreeSold == 0)
        {
            myCosmetics.headsetButtons[2].interactable = true;
        }
        else
        {
            myCosmetics.headsetButtons[2].interactable = false;
        }

        if (zelAmount >= 1800 && headsetFourSold == 0)
        {
            myCosmetics.headsetButtons[3].interactable = true;
        }
        else
        {
            myCosmetics.headsetButtons[3].interactable = false;
        }
    }


    //handles our save and deletion of prefs.
    public void SavePrefs()
    {
        PlayerPrefs.SetInt("ZELAmount", zelAmount);
        PlayerPrefs.Save();
    }

    public void ResetPrefs()
    {
        zelAmount = 0;
        PlayerPrefs.DeleteAll();
    }

    //Handles how we buy our currency.
    public void BuyZel(int cost)
    {
        zelAmount += cost;
        SavePrefs();
    }
}