using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizerPrefs : MonoBehaviour
{
    public StoreManagement storeSettings;
    
    public Sprite charWeaponSprite;


    //A reference to our ints that keep track of what is selected.
    public int i;
    public int e;
    public int o;
    public int a;
    public int u;
    public int b;

    //A reference to our customization buttons;
    [System.Serializable]
    public struct CustomizedButtons
    {
        public Button[] armButtons;
        public Button[] shirtsButtons;
        public Button[] rifleButtons;
        public Button[] handgunButtons;
        public Button[] headsetButtons;
        public Button[] hairButtons;
    }


    public Sprite[] armSprite;
    public Sprite[] shirtSprite;
    public Sprite[] rifleSprite;
    public Sprite[] handgunSprite;
    public Sprite[] headsetSprite;
    public Sprite[] hairSprite;

    [SerializeField]
    public CustomizedButtons myCustomizeButtons;
    
    void Start()
    {
        storeSettings = GetComponentInChildren<StoreManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectVal();
    }

    public void SetRifle(int o)
    { 
        Debug.Log(o);
        //charWeaponSprite = rifleSprite[o];
        SavePrefs();
    }

    public void SetArm(int i)
    {
        SavePrefs();
    }

    public void SetHeadSet(int u)
    {
        SavePrefs();
    }

    public void SetHandGun(int a)
    {
        SavePrefs();
    }

    public void SetShirt(int e)
    {
        SavePrefs();
    }

    public void SetHair(int b)
    {
        SavePrefs();
    }

    void SelectVal()
    {
        if (StoreManagement.weaponOneSold == 1 && o != 0)
        {
            myCustomizeButtons.rifleButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.rifleButtons[0].interactable = false;
        }

        if (StoreManagement.weaponTwoSold == 1 && o != 1)
        {
            myCustomizeButtons.rifleButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.rifleButtons[1].interactable = false;
        }

        if (StoreManagement.weaponThreeSold == 1 && o != 2)
        {
            myCustomizeButtons.rifleButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.rifleButtons[2].interactable = false;
        }

        if (StoreManagement.weaponFourSold == 1 && o != 3)
        {
            myCustomizeButtons.rifleButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.rifleButtons[3].interactable = false;
        }


        if (StoreManagement.armOneSold == 1 && i != 0)
        {
            myCustomizeButtons.armButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.armButtons[0].interactable = false;
        }

        if (StoreManagement.armTwoSold == 1 && i != 1)
        {
            myCustomizeButtons.armButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.armButtons[1].interactable = false;
        }

        if (StoreManagement.armThreeSold == 1 && i != 2)
        {
            myCustomizeButtons.armButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.armButtons[2].interactable = false;
        }

        if (StoreManagement.armFourSold == 1 && i != 3)
        {
            myCustomizeButtons.armButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.armButtons[3].interactable = false;
        }

        if (StoreManagement.shirtOneSold == 1 && e != 0)
        {
            myCustomizeButtons.shirtsButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[0].interactable = false;
        }

        if (StoreManagement.shirtTwoSold == 1 && e != 1)
        {
            myCustomizeButtons.shirtsButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[1].interactable = false;
        }

        if (StoreManagement.shirtThreeSold == 1 && e != 2)
        {
            myCustomizeButtons.shirtsButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[2].interactable = false;
        }

        if (StoreManagement.hairFourSold == 1 && e != 3)
        {
            myCustomizeButtons.hairButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[3].interactable = false;
        }

        if (StoreManagement.hairOneSold == 1 && b != 0)
        {
            myCustomizeButtons.hairButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[0].interactable = false;
        }

        if (StoreManagement.hairTwoSold == 1 && b != 1)
        {
            myCustomizeButtons.shirtsButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[1].interactable = false;
        }

        if (StoreManagement.hairThreeSold == 1 && b != 2)
        {
            myCustomizeButtons.hairButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[2].interactable = false;
        }

        if (StoreManagement.hairFourSold == 1 && b != 3)
        {
            myCustomizeButtons.hairButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[3].interactable = false;
        }

        if (StoreManagement.hairOneSold == 1 && u != 0)
        {
            myCustomizeButtons.hairButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[0].interactable = false;
        }

        if (StoreManagement.hairTwoSold == 1 && u != 1)
        {
            myCustomizeButtons.shirtsButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[1].interactable = false;
        }

        if (StoreManagement.hairThreeSold == 1 && u != 2)
        {
            myCustomizeButtons.hairButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[2].interactable = false;
        }

        if (StoreManagement.hairFourSold == 1 && u != 3)
        {
            myCustomizeButtons.hairButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[3].interactable = false;
        }

        if (StoreManagement.hairOneSold == 1 && a != 0)
        {
            myCustomizeButtons.hairButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[0].interactable = false;
        }

        if (StoreManagement.hairTwoSold == 1 && a != 1)
        {
            myCustomizeButtons.shirtsButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[1].interactable = false;
        }

        if (StoreManagement.hairThreeSold == 1 && a != 2)
        {
            myCustomizeButtons.hairButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[2].interactable = false;
        }

        if (StoreManagement.hairFourSold == 1 && a != 3)
        {
            myCustomizeButtons.hairButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[3].interactable = false;
        }
    }

    void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
