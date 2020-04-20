using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizerPrefs : MonoBehaviour
{
    public StoreManagement storeSettings;

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

    [SerializeField]
    public CustomizedButtons myCustomizeButtons;
    
    void Start()
    {
        storeSettings = GetComponentInChildren<StoreManagement>();
        CheckCustomPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        RifleVal();
        VisorVal();
        ArmVal();
        ShirtVal();
        HandGunVal();
        HairVal();
    }

    void CheckCustomPrefs()
    {
        a = PlayerPrefs.GetInt("A");
        e = PlayerPrefs.GetInt("E");
        i = PlayerPrefs.GetInt("I");
        o = PlayerPrefs.GetInt("O");
        u = PlayerPrefs.GetInt("U");
        b = PlayerPrefs.GetInt("B");
    }

    public void SetRifleOne()
    {
        e = 0;
        PlayerPrefs.SetInt("E", 0);
        UnSetHandGun();
        SavePrefs();
    }

    public void SetRifleTwo()
    {
        e = 1;
        PlayerPrefs.SetInt("E", 1);
        UnSetHandGun();
        SavePrefs();
    }

    public void SetRifleThree()
    {
        e = 2;
        PlayerPrefs.SetInt("E", 2);
        UnSetHandGun();
        SavePrefs();
    }

    public void SetRifleFour()
    {
        e = 3;
        PlayerPrefs.SetInt("E", 3);
        UnSetHandGun();
        SavePrefs();
    }

    public void SetArmOne()
    {
        i = 0;
        PlayerPrefs.SetInt("I", 0);
        SavePrefs();
    }

    public void SetArmTwo()
    {
        i = 1;
        PlayerPrefs.SetInt("I", 1);
        SavePrefs();
    }

    public void SetArmThree()
    {
        i = 2;
        PlayerPrefs.SetInt("I", 2);
        SavePrefs();
    }

    public void SetArmFour()
    {
        i = 3;
        PlayerPrefs.SetInt("I", 3);
        SavePrefs();
    }

    public void SetHeadSetOne()
    {
        o = 0;
        PlayerPrefs.SetInt("O", 0);
        SavePrefs();
    }

    public void SetHeadSetTwo()
    {
        o = 1;
        PlayerPrefs.SetInt("O", 1);
        SavePrefs();
    }

    public void SetHeadSetThree()
    {
        o = 2;
        PlayerPrefs.SetInt("O", 2);
        SavePrefs();
    }

    public void SetHeadSetFour()
    {
        o = 3;
        PlayerPrefs.SetInt("O", 3);
        SavePrefs();
    }

    public void SetHandGunOne()
    {
        a = 0;
        PlayerPrefs.SetInt("A", 0);
        UnSetRifle();
        SavePrefs();
    }

    public void SetHandGunTwo()
    {
        a = 1;
        PlayerPrefs.SetInt("A", 1);
        UnSetRifle();
        SavePrefs();
    }

    public void SetHandGunThree()
    {
        a = 2;
        PlayerPrefs.SetInt("A", 2);
        UnSetRifle();
        SavePrefs();
    }

    public void SetHandGunFour()
    {
        a = 3;
        PlayerPrefs.SetInt("A", 3);
        UnSetRifle();
        SavePrefs();
    }

    public void SetShirtOne()
    {
        u = 0;
        PlayerPrefs.SetInt("U", 0);
        SavePrefs();
    }

    public void SetShirtTwo()
    {
        u = 1;
        PlayerPrefs.SetInt("U", 1);
        SavePrefs();
    }

    public void SetShirtThree()
    {
        u = 2;
        PlayerPrefs.SetInt("U", 2);
        SavePrefs();
    }

    public void SetShirtFour()
    {
        u = 3;
        PlayerPrefs.SetInt("U", 3);
        SavePrefs();
    }

    public void SetHairOne()
    {
        b = 0;
        PlayerPrefs.SetInt("B", 0);
        SavePrefs();
    }

    public void SetHairTwo()
    {
        b = 1;
        PlayerPrefs.SetInt("B", 1);
        SavePrefs();
    }

    public void SetHairThree()
    {
        b = 2;
        PlayerPrefs.SetInt("B", 2);
        SavePrefs();
    }

    public void SetHairFour()
    {
        b = 3;
        PlayerPrefs.SetInt("B", 3);
        SavePrefs();
    }

    void RifleVal()
    {
        if (StoreManagement.weaponOneSold == 1 && e != 0)
        {
            myCustomizeButtons.rifleButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.rifleButtons[0].interactable = false;
        }

        if (StoreManagement.weaponTwoSold == 1 && e != 1)
        {
            myCustomizeButtons.rifleButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.rifleButtons[1].interactable = false;
        }

        if (StoreManagement.weaponThreeSold == 1 && e != 2)
        {
            myCustomizeButtons.rifleButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.rifleButtons[2].interactable = false;
        }

        if (StoreManagement.weaponFourSold == 1 && e != 3)
        {
            myCustomizeButtons.rifleButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.rifleButtons[3].interactable = false;
        }

        if (StoreManagement.weaponFourSold == 1 && e == 4)
        {
            myCustomizeButtons.rifleButtons[0].interactable = true;
            myCustomizeButtons.rifleButtons[1].interactable = true;
            myCustomizeButtons.rifleButtons[2].interactable = true;
            myCustomizeButtons.rifleButtons[3].interactable = true;
        }
    }

    void HandGunVal()
    {
        if (StoreManagement.handGunOneSold == 1 && a != 0)
        {
            myCustomizeButtons.handgunButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.handgunButtons[0].interactable = false;
        }

        if (StoreManagement.handGunTwoSold == 1 && a != 1)
        {
            myCustomizeButtons.handgunButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.handgunButtons[1].interactable = false;
        }

        if (StoreManagement.handGunThreeSold == 1 && a != 2)
        {
            myCustomizeButtons.handgunButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.handgunButtons[2].interactable = false;
        }

        if (StoreManagement.handGunFourSold == 1 && a != 3)
        {
            myCustomizeButtons.handgunButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.handgunButtons[3].interactable = false;
        }

        if (StoreManagement.handGunFourSold == 1 && a == 4)
        {
            myCustomizeButtons.handgunButtons[0].interactable = true;
            myCustomizeButtons.handgunButtons[1].interactable = true;
            myCustomizeButtons.handgunButtons[2].interactable = true;
            myCustomizeButtons.handgunButtons[3].interactable = true;
        }
    }

    void VisorVal()
    {
        if (StoreManagement.headsetOneSold == 1 && o != 0)
        {
            myCustomizeButtons.headsetButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.headsetButtons[0].interactable = false;
        }

        if (StoreManagement.headsetTwoSold == 1 && o != 1)
        {
            myCustomizeButtons.headsetButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.headsetButtons[1].interactable = false;
        }

        if (StoreManagement.headsetThreeSold == 1 && o != 2)
        {
            myCustomizeButtons.headsetButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.headsetButtons[2].interactable = false;
        }

        if (StoreManagement.headsetFourSold == 1 && o != 3)
        {
            myCustomizeButtons.headsetButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.headsetButtons[3].interactable = false;
        }
    }

    void HairVal()
    {
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
            myCustomizeButtons.hairButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[1].interactable = false;
        }

        if (StoreManagement.hairThreeSold == 1 && b != 2)
        {
            myCustomizeButtons.hairButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[2].interactable = false;
        }

        if (StoreManagement.hairFourSold == 1 && b != 3)
        {
            myCustomizeButtons.hairButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.hairButtons[3].interactable = false;
        }
    }

    void ArmVal()
    {
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
    }

    void ShirtVal()
    {
        if (StoreManagement.shirtOneSold == 1 && u != 0)
        {
            myCustomizeButtons.shirtsButtons[0].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[0].interactable = false;
        }

        if (StoreManagement.shirtTwoSold == 1 && u != 1)
        {
            myCustomizeButtons.shirtsButtons[1].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[1].interactable = false;
        }

        if (StoreManagement.shirtThreeSold == 1 && u != 2)
        {
            myCustomizeButtons.shirtsButtons[2].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[2].interactable = false;
        }

        if (StoreManagement.shirtFourSold == 1 && u != 3)
        {
            myCustomizeButtons.shirtsButtons[3].interactable = true;
        }
        else
        {
            myCustomizeButtons.shirtsButtons[3].interactable = false;
        }
    }


    public void UnSetHandGun()
    {
        a = 4;
        PlayerPrefs.SetInt("A", 4);
    }

    public void UnSetRifle()
    {
        e = 4;
        PlayerPrefs.SetInt("E", 4);
    }


    void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
