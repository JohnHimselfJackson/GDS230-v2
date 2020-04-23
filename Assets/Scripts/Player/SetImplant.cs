using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetImplant : MonoBehaviour
{
    public ImplantAbility myImplant;
    // Start is called before the first frame update
    void Start()
    {
        myImplant = GetComponent<ImplantAbility>();
    }

    public void SetDash()
    {
        myImplant.implant = ImplantAbility.Implant.BioticDash;
    }

    public void SetShield()
    {
        myImplant.implant = ImplantAbility.Implant.Shield;
    }
}
