using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationController : MonoBehaviour
{
    //Standard order for sprites in the arrays is: default, blue, green then Pink
    public Gun gunScript;
    public Sprite[] hair;
    public Sprite[] body;
    public Sprite[] headset;
    public Sprite[] arm;
    public Sprite[] pistolArm;
    public Sprite[] pistolShirt;
    public Sprite[] rifleArm;
    public Sprite[] rifleShirt;

    public SpriteRenderer hairSr;
    public SpriteRenderer bodySr;
    public SpriteRenderer weaponArmSr;
    public SpriteRenderer armSr;
    public SpriteRenderer headsetSr;
    public SpriteRenderer shirtSr;




    // Start is called before the first frame update
    void Start()
    {
        int hairInt = ClampPlayerPrefs(PlayerPrefs.GetInt("playerHair",0));
        hairSr.sprite = hair[hairInt];
        int bodyInt = ClampPlayerPrefs(PlayerPrefs.GetInt("playerBody",0));
        bodySr.sprite = body[bodyInt];
        int headsetInt = ClampPlayerPrefs(PlayerPrefs.GetInt("playerHeadset", 0));
        headsetSr.sprite = headset[headsetInt];
        int armInt = ClampPlayerPrefs(PlayerPrefs.GetInt("playerArm", 0));
        armSr.sprite = arm[armInt];

        if (gunScript.weaponReference.weaponType == "pistol")
        {
            int shirtInt = ClampPlayerPrefs(PlayerPrefs.GetInt("playerShirt", 0));
            shirtSr.sprite = pistolShirt[shirtInt];
            int weaponArmInt = ClampPlayerPrefs(PlayerPrefs.GetInt("weaponArm", 0));
            weaponArmSr.sprite = pistolArm[weaponArmInt];
        }
        if (gunScript.weaponReference.weaponType == "rifle")
        {
            int shirtInt = ClampPlayerPrefs(PlayerPrefs.GetInt("playerShirt", 0));
            shirtSr.sprite = rifleShirt[shirtInt];
            int weaponArmInt = ClampPlayerPrefs(PlayerPrefs.GetInt("weaponArm", 0));
            weaponArmSr.sprite = rifleArm[weaponArmInt];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// always returns number 0-3
    /// </summary>
    /// <param name="intGiven"></param>
    /// <returns></returns>
    int ClampPlayerPrefs(int intGiven)
    {
        if (intGiven > 3 || intGiven < 0)
        {
            return 1;
        }
        else
        {
            return intGiven;
        }
    }



}
