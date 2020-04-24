using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void PlayButtonPressSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    public void PlayButtonPressBackSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPressBack");
    }
}
