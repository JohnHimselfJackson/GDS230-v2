using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplantAbility : MonoBehaviour
{
    public enum Implant {BioticDash};
    public Implant implant;

    public GameObject player;

    public bool bDash;
    public float speed;
    public Vector3 range;
    public LayerMask myLayer;

    void Start()
    {
        
    }

    void Update()
    {
        UseAbility();
    }

    void UseAbility()
    {
        switch (implant)
        {
            case (Implant.BioticDash):
                BioticDash();
                break;
        }
    }

    void BioticDash()
    {
        if(Input.GetButtonDown("Space"))
        {
            //Raycast to find players position
        }
    }
}
