using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePreferences : MonoBehaviour
{
    //A reference to our store helper script.
    StoreHelper storeHelper;

    //A reference to our currency.
    int ZELAmount;

    //Text for our currency.
    public Text ZELAmountText;

    //A reference to our item prices being sold.
    public Text[] itemPrices;
    public Text[] characterPrices;
    public Text[] weaponPrices;

    // A reference to our buying buttons.
    public Button[] buttons;

    void Start()
    {
        //Gets our currency from the prefs.
        ZELAmount = PlayerPrefs.GetInt("ZELAmount");
        storeHelper = GetComponent<StoreHelper>();
    }

    void Update()
    {
        //Sets our currency text;
        ZELAmountText.text = "ZEL: " + ZELAmount.ToString();

        //Gets the ints for our items.
        StoreHelper.isGreenSold = PlayerPrefs.GetInt("IsGreenSold");
        StoreHelper.isRedSold = PlayerPrefs.GetInt("IsRedSold");
        StoreHelper.isYellowSold = PlayerPrefs.GetInt("IsYellowSold");
        StoreHelper.isBlueSold = PlayerPrefs.GetInt("IsBlueSold");
        StoreHelper.isBlackSold = PlayerPrefs.GetInt("IsBlackSold");

        //Gets the ints for our characters.
        StoreHelper.isTheMackSold = PlayerPrefs.GetInt("IsTheMackSold");
        StoreHelper.isJohnsonSold = PlayerPrefs.GetInt("IsJohnsonSold");
        StoreHelper.isCarbonFiberSold = PlayerPrefs.GetInt("IsCarbonFiberSold");
        StoreHelper.isThornlieSold = PlayerPrefs.GetInt("IsThornlieSold");
        StoreHelper.isMillerinoSold = PlayerPrefs.GetInt("IsMillerinoSold");

        //Purchase checks for our skins.
        GreenSoldCheck();
        RedSoldCheck();
        YellowSoldCheck();
        BlueSoldCheck();
        BlackSoldCheck();

        //Purchase checks for our characters.
        MackSoldCheck();
        JohnsonSoldCheck();
        CarbonFiberSoldCheck();
        ThornlieSoldCheck();
        MillerinoSoldCheck();

        //Purchase checks for our weapons.
    }

    //Called when the green button is pressed - added to the OnClick event located in the button itself.
    public void BuyGreenSkin()
    {
        SkinPurchase();
        PlayerPrefs.SetInt("IsGreenSold", 1);
        itemPrices[0].text = "Sold!";
        buttons[0].gameObject.SetActive(false);
    }

    //Handles the purchasing of this item.
    public void BuyRedSkin()
    {
        SkinPurchase();
        PlayerPrefs.SetInt("IsRedSold", 1);
        itemPrices[1].text = "Sold!";
        buttons[1].gameObject.SetActive(false);
    }

    //Handles the purchasing of this item.
    public void BuyYellowSkin()
    {
        SkinPurchase();
        PlayerPrefs.SetInt("IsYellowSold", 1);
        itemPrices[2].text = "Sold!";
        buttons[2].gameObject.SetActive(false);
    }

    //Handles the purchasing of this item.
    public void BuyBlueSkin()
    {
        SkinPurchase();
        PlayerPrefs.SetInt("IsBlueSold", 1);
        itemPrices[3].text = "Sold!";
        buttons[3].gameObject.SetActive(false);
    }

    //Handles the purchasing of this item.
    public void BuyBlackSkin()
    {
        SkinPurchase();
        PlayerPrefs.SetInt("IsBlackSold", 1);
        itemPrices[4].text = "Sold!";
        buttons[4].gameObject.SetActive(false);
    }

    //Handles the purchasing of this character.
    public void BuyTheMack()
    {
        CharacterPurchase();
        PlayerPrefs.SetInt("IsTheMackSold", 1);
        characterPrices[0].text = "Sold!";
        buttons[5].gameObject.SetActive(false);
    }

    public void BuyJohnson()
    {
        CharacterPurchase();
        PlayerPrefs.SetInt("IsJohnsonSold", 1);
        characterPrices[1].text = "Sold!";
        buttons[6].gameObject.SetActive(false);
    }

    public void BuyCarbonFiber()
    {
        CharacterPurchase();
        PlayerPrefs.SetInt("IsCarbonFiberSold", 1);
        characterPrices[2].text = "Sold!";
        buttons[7].gameObject.SetActive(false);
    }

    public void BuyThornlie()
    {
        CharacterPurchase();
        PlayerPrefs.SetInt("IsThornlieSold", 1);
        characterPrices[3].text = "Sold!";
        buttons[8].gameObject.SetActive(false);
    }

    public void BuyMillerino()
    {
        CharacterPurchase();
        PlayerPrefs.SetInt("IsMillerinoSold", 1);
        characterPrices[4].text = "Sold!";
        buttons[9].gameObject.SetActive(false);
    }

    //Currency buying.
    public void Buy100ZEL()
    {
        ZELAmount += 100;
        PlayerPrefs.SetInt("ZELAmount", ZELAmount);
    }

    //Currency buying.
    public void Buy250ZEL()
    {
        ZELAmount += 250;
        PlayerPrefs.SetInt("ZELAmount", ZELAmount);
    }

    //Currency buying.
    public void Buy600ZEL()
    {
        ZELAmount += 600;
        PlayerPrefs.SetInt("ZELAmount", ZELAmount);

    }

    //This just saves the player prefs for the currency.
    public void ExitShop()
    {
        PlayerPrefs.SetInt("ZELAmount", ZELAmount);
    }

    //Resets the player prefs and sets buttons to true, also sets ALL prices to normal. FOR TEST PURPOSES YO.
    public void ResetPlayerPrefs()
    {
        ZELAmount = 0;
        buttons[0].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(true);
        buttons[3].gameObject.SetActive(true);
        buttons[4].gameObject.SetActive(true);
        buttons[5].gameObject.SetActive(true);
        buttons[6].gameObject.SetActive(true);
        buttons[7].gameObject.SetActive(true);
        buttons[8].gameObject.SetActive(true);
        buttons[9].gameObject.SetActive(true);

        itemPrices[0].text = "ZEL: 500";
        itemPrices[1].text = "ZEL: 500";
        itemPrices[2].text = "ZEL: 500";
        itemPrices[3].text = "ZEL: 500";
        itemPrices[4].text = "ZEL: 500";

        characterPrices[0].text = "ZEL: 800";
        characterPrices[1].text = "ZEL: 800";
        characterPrices[2].text = "ZEL: 800";
        characterPrices[3].text = "ZEL: 800";
        characterPrices[4].text = "ZEL: 800";

        PlayerPrefs.DeleteAll();
    }

    //Handles our currency payment for the skins.
    void SkinPurchase()
    {
        ZELAmount -= 500;
    }

    void CharacterPurchase()
    {
        ZELAmount -= 800;
    }

    //Handles if our object has been sold or not.
    void GreenSoldCheck()
    {
        if (ZELAmount >= 500 && StoreHelper.isGreenSold == 0)
        {
            buttons[0].gameObject.SetActive(true);
        }
        else
        {
            buttons[0].gameObject.SetActive(false);
        }
    }

    //Handles if our object has been sold or not.
    void RedSoldCheck()
    {
        if (ZELAmount >= 500 && StoreHelper.isRedSold == 0)
        {
            buttons[1].gameObject.SetActive(true);
        }
        else
        {
            buttons[1].gameObject.SetActive(false);
        }
    }

    //Handles if our object has been sold or not.
    void YellowSoldCheck()
    {
        if (ZELAmount >= 500 && StoreHelper.isYellowSold == 0)
        {
            buttons[2].gameObject.SetActive(true);
        }
        else
        {
            buttons[2].gameObject.SetActive(false);
        }
    }

    //Handles if our object has been sold or not.
    void BlueSoldCheck()
    {
        if (ZELAmount >= 500 && StoreHelper.isBlueSold == 0)
        {
            buttons[3].gameObject.SetActive(true);
        }
        else
        {
            buttons[3].gameObject.SetActive(false);
        }
    }

    //Handles if our object has been sold or not.
    void BlackSoldCheck()
    {
        if (ZELAmount >= 500 && StoreHelper.isBlackSold == 0)
        {
            buttons[4].gameObject.SetActive(true);
        }
        else
        {
            buttons[4].gameObject.SetActive(false);
        }
    }

    //Handles if our object has been sold or not.
    void MackSoldCheck()
    {
        if (ZELAmount >= 800 && StoreHelper.isTheMackSold == 0)
        {
            buttons[5].gameObject.SetActive(true);
        }
        else
        {
            buttons[5].gameObject.SetActive(false);
        }
    }

    void JohnsonSoldCheck()
    {
        if (ZELAmount >= 800 && StoreHelper.isJohnsonSold == 0)
        {
            buttons[6].gameObject.SetActive(true);
        }
        else
        {
            buttons[6].gameObject.SetActive(false);
        }
    }

    void CarbonFiberSoldCheck()
    {
        if (ZELAmount >= 800 && StoreHelper.isCarbonFiberSold == 0)
        {
            buttons[7].gameObject.SetActive(true);
        }
        else
        {
            buttons[7].gameObject.SetActive(false);
        }
    }

    void ThornlieSoldCheck()
    {
        if (ZELAmount >= 800 && StoreHelper.isThornlieSold == 0)
        {
            buttons[8].gameObject.SetActive(true);
        }
        else
        {
            buttons[8].gameObject.SetActive(false);
        }
    }

    void MillerinoSoldCheck()
    {
        if (ZELAmount >= 800 && StoreHelper.isMillerinoSold == 0)
        {
            buttons[9].gameObject.SetActive(true);
        }
        else
        {
            buttons[9].gameObject.SetActive(false);
        }
    }
}
