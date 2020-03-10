using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CustomizePreferences : MonoBehaviour
{
    //A reference to our store helper script.
    public StoreHelper storeHelper;

    //A reference to our 3 dropdowns for customization.
    public Dropdown charactersDropDown;
    public Dropdown skinsDropDown;
    public Dropdown weaponsDropDown;

    // A reference to our customize error message texts.
    public Text ownerText;
    public Text characterOwnText;
    public Text weaponOwnText;

    public Text bioText;

    //A reference to our 3 images that appear above the dropdowns.
    public Image skinPicture;
    public Image weaponPicture;
    public Image charPicture;

    //A reference to our strings that our player prefs use.
    const string charName = "charactersoption";
    const string skinName = "skinsoption";
    const string weaponName = "weaponsoption";

    // Handles what happens to our customization prefs during a Unity event & saves them.
    void Awake()
    {
        charactersDropDown.onValueChanged.AddListener(new UnityAction<int>(indexer =>
        {
            PlayerPrefs.SetInt(charName, charactersDropDown.value);
            PlayerPrefs.Save();
        }));

        skinsDropDown.onValueChanged.AddListener(new UnityAction<int>(indexer =>
        {
            PlayerPrefs.SetInt(skinName, skinsDropDown.value);
            PlayerPrefs.Save();
        }));

        weaponsDropDown.onValueChanged.AddListener(new UnityAction<int>(indexer =>
        {
            PlayerPrefs.SetInt(weaponName, weaponsDropDown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        storeHelper = GetComponent<StoreHelper>();

        //Sets our pref values to default values initially.
        charactersDropDown.value = PlayerPrefs.GetInt(charName, 0);
        skinsDropDown.value = PlayerPrefs.GetInt(skinName, 0);
        weaponsDropDown.value = PlayerPrefs.GetInt(weaponName, 0);

        //sets our integer (i, e, o) values to be the same as its corresponding Dropdown value.
        StoreHelper.i = skinsDropDown.value;
        StoreHelper.e = charactersDropDown.value;
        StoreHelper.o = weaponsDropDown.value;
    }

    void Update()
    {
        StoreHelper.i = skinsDropDown.value;
        StoreHelper.e = charactersDropDown.value;
        Debug.Log(StoreHelper.e);
        StoreHelper.o = weaponsDropDown.value;
        CharacterState();
        PictureState();
        WeaponState();
    }


    //Sets our character prefs in game.
    public void SetCharacter()
    {
        PlayerPrefs.SetInt(charName, charactersDropDown.value);
    }

    //Sets our skin prefs in game.
    public void SetSkin()
    {
        PlayerPrefs.SetInt(skinName, skinsDropDown.value);
    }

    //Sets our skin prefs in game.
    public void SetWeapon()
    {
        PlayerPrefs.SetInt(weaponName, weaponsDropDown.value);
    }

    //Handles what color our Skin Picture changes to depending on i.
    void PictureState()
    {
        switch (StoreHelper.i)
        {
            case 4:
                if (StoreHelper.isBlackSold == 1)
                {
                    skinPicture.color = Color.black;
                    ownerText.text = "NICE SKIN".ToString();
                    bioText.text = "".ToString();
                }
                else
                {
                    skinPicture.color = Color.white;
                    ownerText.text = "YOU DO NOT OWN THIS SKIN".ToString();
                }
                break;
            case 3:
                if (StoreHelper.isYellowSold == 1)
                {
                    skinPicture.color = Color.yellow;
                    ownerText.text = "HAPPY SKIN".ToString();
                    bioText.text = "".ToString();
                }
                else
                {
                    skinPicture.color = Color.white;
                    ownerText.text = "YOU DO NOT OWN THIS SKIN".ToString();
                }
                    break;
            case 2:
                if (StoreHelper.isGreenSold == 1)
                {
                    skinPicture.color = Color.green;
                    ownerText.text = "GROOVY SKIN".ToString();
                    bioText.text = "".ToString();
                }
                else
                {
                    skinPicture.color = Color.white;
                    ownerText.text = "YOU DO NOT OWN THIS SKIN".ToString();
                }
                break;
            case 1:
                if (StoreHelper.isBlueSold == 1)
                {
                    skinPicture.color = Color.blue;
                    ownerText.text = "COOL SKIN".ToString();
                    bioText.text = "".ToString();
                }
                else
                {
                    skinPicture.color = Color.white;
                    ownerText.text = "YOU DO NOT OWN THIS SKIN".ToString();
                }
                break;
            case 0:
                if (StoreHelper.isRedSold == 1)
                {
                    skinPicture.color = Color.red;
                    ownerText.text = "SMOKING SKIN".ToString();
                }
                else
                {
                    skinPicture.color = Color.white;
                    ownerText.text = "YOU DO NOT OWN THIS SKIN".ToString();
                }
                break;
            default:
                Debug.Log("REEEEE");
                break;
        }
    }

    //Handles what color our Character Picture changes to depending on e.
    void CharacterState()
    {
        switch (StoreHelper.e)
        {
            case 0:
                if (StoreHelper.isTheMackSold == 1)
                {
                    charPicture.color = Color.red;
                    characterOwnText.text = "Smacko with El Macko!".ToString();
                    bioText.text = "Age: 21. Height: 5'11`'' Loves cookies and shooting off the heads of his enemies. Mack Attack has got your back! Abandoned as a young child, Mack grew up baking cookies at his orphanage for hours on end. Churning out those double fudge & white choc cookies to raise money for more cookie dough. Nowadays Mack finds young cubs on the street and raises them as his own. Raises them into unstobbable killing machines of mega chocolatey death. He also teaches them how to bake, allowing for each individual to branch out into other non-lethal professions. Mack owns several bakeries and Cafes where he employs the youth of tomorrow. Thats the way the cookie crumbles!".ToString();
                }
                else
                {
                    charPicture.color = Color.white;
                    characterOwnText.text = "YOU DO NOT OWN THIS CHARACTER".ToString();
                    bioText.text = "You don't deserve to know my backstory FILTH!!!".ToString();
                }
                break;
            case 1:
                if (StoreHelper.isJohnsonSold == 1)
                {
                    charPicture.color = Color.blue;
                    characterOwnText.text = "Johnson eating 'EM UP!".ToString();
                }
                else
                {
                    charPicture.color = Color.white;
                    characterOwnText.text = "YOU DO NOT OWN THIS CHARACTER".ToString();
                    bioText.text = "You don't deserve to know my backstory FILTH!!!".ToString();
                }
                break;
            case 2:
                if (StoreHelper.isCarbonFiberSold == 1)
                {
                    charPicture.color = Color.green;
                    characterOwnText.text = "Tough as Nails!".ToString();
                }
                else
                {
                    charPicture.color = Color.white;
                    characterOwnText.text = "YOU DO NOT OWN THIS CHARACTER".ToString();
                    bioText.text = "You don't deserve to know my backstory FILTH!!!".ToString();
                }
                break;
            case 3:
                if (StoreHelper.isThornlieSold == 1)
                {
                    charPicture.color = Color.yellow;
                    characterOwnText.text = "Beware the Thorns!".ToString();
                }
                else
                {
                    charPicture.color = Color.white;
                    characterOwnText.text = "YOU DO NOT OWN THIS CHARACTER".ToString();
                    bioText.text = "You don't deserve to know my backstory FILTH!!!".ToString();
                }
                break;
            case 4:
                if (StoreHelper.isMillerinoSold == 1)
                {
                    charPicture.color = Color.black;
                    characterOwnText.text = "Miller of souls".ToString();
                }
                else
                {
                    charPicture.color = Color.white;
                    characterOwnText.text = "YOU DO NOT OWN THIS CHARACTER".ToString();
                    bioText.text = "So you want to know my story eh? Spend ya dollaridoos n find out!! ;)".ToString();
                }
                break;
            default:
                Debug.Log("REEEEE");
                break;
        }
    }

    void WeaponState()
    {
        switch (StoreHelper.o)
        {
            case 4:
                weaponPicture.color = Color.black;
                break;
            case 3:
                weaponPicture.color = Color.yellow;
                break;
            case 2:
                weaponPicture.color = Color.green;
                break;
            case 1:
                weaponPicture.color = Color.blue;
                break;
            case 0:
                weaponPicture.color = Color.red;
                break;
            default:
                Debug.Log("REEEEE");
                break;
        }
    }
}
