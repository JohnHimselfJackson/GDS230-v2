using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreHelper : MonoBehaviour
{
    //Our currency and currency Text.
    public static int ZELAmount;
    public static int i;
    public static int e;
    public static int o;

    public Text ZELText;

    //A reference to our skin integers that are sold or unsold.
    public static int isGreenSold;
    public static int isRedSold;
    public static int isYellowSold;
    public static int isBlueSold;
    public static int isBlackSold;

    //A reference to our character integers that are sold or unsold.
    public static int isTheMackSold;
    public static int isJohnsonSold;
    public static int isCarbonFiberSold;
    public static int isThornlieSold;
    public static int isMillerinoSold;

    //A reference to our skins In-Game.
    public GameObject green;
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;
    public GameObject black;

    //A reference to our characters In-Game.
    public Sprite normal;
    public Sprite theMack;
    public Sprite johnSon;
    public Sprite carbonFiber;
    public Sprite thornLie;
    public Sprite Millerino;

    //A reference to our Player.
    public SpriteRenderer player;
    public SpriteRenderer reds;
    public SpriteRenderer greens;
    public SpriteRenderer yellows;
    public SpriteRenderer blues;
    public SpriteRenderer blacks;


    void Start()
    {
        //Gets our player prefs for our currency and our skins.
        ZELAmount = PlayerPrefs.GetInt("ZELAmount");

        //Gets our customization selection value and then sets it to i & e.
        i = PlayerPrefs.GetInt("skinsoption");
        e = PlayerPrefs.GetInt("charactersoption");

        //Gets the prefs for our skin items.
        isGreenSold = PlayerPrefs.GetInt("IsGreenSold");
        isRedSold = PlayerPrefs.GetInt("IsRedSold");
        isYellowSold = PlayerPrefs.GetInt("IsYellowSold");
        isBlueSold = PlayerPrefs.GetInt("IsBlueSold");
        isBlackSold = PlayerPrefs.GetInt("IsBlackSold");

        //Gets the prefs for our character items.
        isTheMackSold = PlayerPrefs.GetInt("IsTheMackSold");
        isJohnsonSold = PlayerPrefs.GetInt("IsJohnsonSold");
        isCarbonFiberSold = PlayerPrefs.GetInt("IsCarbonFiberSold");
        isThornlieSold = PlayerPrefs.GetInt("IsThornlieSold");
        isMillerinoSold = PlayerPrefs.GetInt("IsMillerinoSold");

        //Calls the Sold Check functions for each character item.
        CharacterSold();

        //Calls the Sold Check functions for each skin item.
        SkinSold();
    }

    void Update()
    {
        //Sets our currency to a text.
        ZELText.text = "ZEL: " + ZELAmount.ToString();
        Debug.Log(e);
        Debug.Log("The current selection has a value of " + isMillerinoSold);
    }

    public void SaveMoney()
    {
        //Saves our currency in prefs.
        PlayerPrefs.SetInt("ZELAmount", ZELAmount);
    }

    //Checks to see if our skin items are sold & selected then handles what appears on our character.
    void SkinSold()
    {
        if (isRedSold == 1 && i == 0)
        {
            red.SetActive(true);
            reds.sprite = player.sprite;
        }
        if (isBlueSold == 1 && i == 1)
        {
            blue.SetActive(true);
            blues.sprite = player.sprite;
        }
        if (isGreenSold == 1 && i == 2)
        {
            green.SetActive(true);
            greens.sprite = player.sprite;
        }
        if (isYellowSold == 1 && i == 3)
        {
            yellow.SetActive(true);
            yellows.sprite = player.sprite;
        }
        if (isBlackSold == 1 && i == 4)
        {
            black.SetActive(true);
            blacks.sprite = player.sprite;
        }
    }

    //Checks to see if our character items are sold & selected then handles what appears on our character.
    void CharacterSold()
    {
        if (isTheMackSold == 1 && e == 0)
        {
            player.sprite = theMack;
        }

        if (isJohnsonSold == 1 && e == 1)
        {
            player.sprite = johnSon;
        }

        if (isCarbonFiberSold == 1 && e == 2)
        {
            player.sprite = carbonFiber;
        }

        if (isThornlieSold == 1 && e == 3)
        {
            player.sprite = thornLie;
        }

        if (isMillerinoSold == 1 && e == 4)
        {
            player.sprite = Millerino;
        }
    }
}
