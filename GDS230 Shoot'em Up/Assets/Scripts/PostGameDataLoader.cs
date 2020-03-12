using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostGameDataLoader : MonoBehaviour
{
    public WeaponHighlightedManager manager;
    public PickUpData gameData;
    public TMP_Text ZelTB;
    public Image ZelImage;
    public TMP_Text weaponNameTB;
    public Button weaponButton;
    public TMP_Text ImplantNameTB;
    public Image ImplantImage;

    public Sprite pistolImage;
    public Sprite rifleImage;
    // Start is called before the first frame update
    void Start()
    {
        gameData = FindObjectOfType<PickUpData>();
        if(gameData.coinsPickedUp < 1)
        {
            ZelTB.text = null;
            ZelImage.gameObject.SetActive(false);
        }
        else
        {
            ZelTB.text = gameData.coinsPickedUp.ToString() + "z";
            ZelImage.gameObject.SetActive(true);
        }

        if (gameData.bossWeapon == null)
        {
            weaponNameTB.text = null;
            weaponButton.gameObject.SetActive(false);
        }
        else
        {
            weaponNameTB.text = gameData.bossWeapon.weaponType;
            weaponButton.gameObject.SetActive(true);
            switch (gameData.bossWeapon.weaponType)
            {
                case "pistol":
                    weaponButton.gameObject.GetComponent<Image>().sprite = pistolImage;
                    break;
                case "rifle":
                    weaponButton.gameObject.GetComponent<Image>().sprite = rifleImage;
                    break;
                    defualt:
                    Debug.Log("weapon type is null despite the srcipt existing");
                    break;

            }
        }

        if (false)
        {
            ImplantNameTB.text = null;
            ImplantImage.gameObject.SetActive(false);
        }
        else
        {
            ImplantNameTB.text = "has implant";
            ImplantImage.gameObject.SetActive(true);
        }
    }

    public void WeaponPressed()
    {
        manager.ShowSelectedWeapon(gameData.bossWeapon);
    }



}
