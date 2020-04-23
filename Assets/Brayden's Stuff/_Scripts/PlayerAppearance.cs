using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    public CustomizerPrefs myCustomPrefs;

    public GameObject[] myHair;
    public GameObject[] myArms;
    public GameObject[] myVisor;
    public GameObject[] myShirt;
    public GameObject[] myRifle;
    public GameObject[] myHandGun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckHair();
        CheckShirt();
        CheckArm();
        CheckRifle();
        CheckVisor();
        CheckHandGun();
    }

    void CheckHair()
    {
        if (myCustomPrefs.b == 0)
        {
            myHair[0].SetActive(true);
        }
        else 
        {
            myHair[0].SetActive(false);
        }

        if (myCustomPrefs.b == 1)
        {
            myHair[1].SetActive(true);
        }
        else
        {
            myHair[1].SetActive(false);
        }

        if (myCustomPrefs.b == 2)
        {
            myHair[2].SetActive(true);
        }
        else
        {
            myHair[2].SetActive(false);
        }

        if (myCustomPrefs.b == 3)
        {
            myHair[3].SetActive(true);
        }
        else
        {
            myHair[3].SetActive(false);
        }
    }

    void CheckArm()
    {
        if (myCustomPrefs.i == 0)
        {
            myArms[0].SetActive(true);
        }
        else
        {
            myArms[0].SetActive(false);
        }

        if (myCustomPrefs.i == 1)
        {
            myArms[1].SetActive(true);
        }
        else
        {
            myArms[1].SetActive(false);
        }

        if (myCustomPrefs.i == 2)
        {
            myArms[2].SetActive(true);
        }
        else
        {
            myArms[2].SetActive(false);
        }

        if (myCustomPrefs.i == 3)
        {
            myArms[3].SetActive(true);
        }
        else
        {
            myArms[3].SetActive(false);
        }
    }

    void CheckRifle()
    {
        if (myCustomPrefs.e == 0)
        {
            myRifle[0].SetActive(true);
        }
        else
        {
            myRifle[0].SetActive(false);
        }

        if (myCustomPrefs.e == 1)
        {
            myRifle[1].SetActive(true);
        }
        else
        {
            myRifle[1].SetActive(false);
        }

        if (myCustomPrefs.e == 2)
        {
            myRifle[2].SetActive(true);
        }
        else
        {
            myRifle[2].SetActive(false);
        }

        if (myCustomPrefs.e == 3)
        {
            myRifle[3].SetActive(true);
        }
        else
        {
            myRifle[3].SetActive(false);
        }

        if (myCustomPrefs.e == 4)
        {
            myRifle[0].SetActive(false);
            myRifle[1].SetActive(false);
            myRifle[2].SetActive(false);
            myRifle[3].SetActive(false);
        }
    }

    void CheckHandGun()
    {
        if (myCustomPrefs.a == 0)
        {
            myHandGun[0].SetActive(true);
        }
        else
        {
            myHandGun[0].SetActive(false);
        }

        if (myCustomPrefs.a == 1)
        {
            myHandGun[1].SetActive(true);
        }
        else
        {
            myHandGun[1].SetActive(false);
        }

        if (myCustomPrefs.a == 2)
        {
            myHandGun[2].SetActive(true);
        }
        else
        {
            myHandGun[2].SetActive(false);
        }

        if (myCustomPrefs.a == 3)
        {
            myHandGun[3].SetActive(true);
        }
        else
        {
            myHandGun[3].SetActive(false);
        }

        if (myCustomPrefs.a == 4)
        {
            myHandGun[0].SetActive(false);
            myHandGun[1].SetActive(false);
            myHandGun[2].SetActive(false);
            myHandGun[3].SetActive(false);
        }
    }

    void CheckVisor()
    {
        if (myCustomPrefs.o == 0)
        {
            myVisor[0].SetActive(true);
        }
        else
        {
            myVisor[0].SetActive(false);
        }

        if (myCustomPrefs.o == 1)
        {
            myVisor[1].SetActive(true);
        }
        else
        {
            myVisor[1].SetActive(false);
        }

        if (myCustomPrefs.o == 2)
        {
            myVisor[2].SetActive(true);
        }
        else
        {
            myVisor[2].SetActive(false);
        }

        if (myCustomPrefs.o == 3)
        {
            myVisor[3].SetActive(true);
        }
        else
        {
            myVisor[3].SetActive(false);
        }
    }

    void CheckShirt()
    {
        if (myCustomPrefs.u == 0)
        {
            myShirt[0].SetActive(true);
        }
        else
        {
            myShirt[0].SetActive(false);
        }

        if (myCustomPrefs.u == 1)
        {
            myShirt[1].SetActive(true);
        }
        else
        {
            myShirt[1].SetActive(false);
        }

        if (myCustomPrefs.u == 2)
        {
            myShirt[2].SetActive(true);
        }
        else
        {
            myShirt[2].SetActive(false);
        }

        if (myCustomPrefs.u == 3)
        {
            myShirt[3].SetActive(true);
        }
        else
        {
            myShirt[3].SetActive(false);
        }
    }
}
