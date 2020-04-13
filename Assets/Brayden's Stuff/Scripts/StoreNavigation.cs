using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreNavigation : MonoBehaviour
{
    public GameObject skinsPanel;
    public GameObject weaponsPanel;
    public GameObject charactersPanel;

    public void Skins()
    {
        skinsPanel.SetActive(true);
        weaponsPanel.SetActive(false);
        charactersPanel.SetActive(false);
    }

    public void Weapons()
    {
        weaponsPanel.SetActive(true);
        skinsPanel.SetActive(false);
        charactersPanel.SetActive(false);
    }

    public void Characters()
    {
        charactersPanel.SetActive(true);
        skinsPanel.SetActive(false);
        weaponsPanel.SetActive(false);
    }
}
