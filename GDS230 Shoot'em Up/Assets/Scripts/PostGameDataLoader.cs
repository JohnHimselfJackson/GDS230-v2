using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostGameDataLoader : MonoBehaviour
{
    PickUpData gameData;
    public TMP_Text ZelTB;
    public Image ZelImage;
    public TMP_Text WeaponNameTB;
    public Image WeaponImage;
    public TMP_Text ImplantNameTB;
    public Image ImplantImage;
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
            WeaponNameTB.text = null;
            WeaponImage.gameObject.SetActive(false);
        }
        else
        {
            WeaponNameTB.text = gameData.bossWeapon.weaponType;
            WeaponImage.gameObject.SetActive(true);
        }

        if (gameData.bossWeapon == null)
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



}
