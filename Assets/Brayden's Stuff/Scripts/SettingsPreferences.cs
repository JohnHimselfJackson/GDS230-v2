using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPreferences : MonoBehaviour
{
    public AudioMixer volMixer;

    public Slider volSlider;

    const string prefName = "optionvalue";
    // Start is called before the first frame update
    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
    }

    public void ChangeVol(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
    }
}
