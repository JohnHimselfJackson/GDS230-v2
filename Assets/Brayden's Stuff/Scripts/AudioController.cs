using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    Scene myScene;
    int myIndex;
    public AudioSource myAudioSource;
    public AudioClip menuClip;
    public AudioClip secondClip;
    public AudioClip gameClip;
    public AudioClip creditsClip;


    void Awake()
    {
        myScene = SceneManager.GetActiveScene();
        myIndex = myScene.buildIndex;
        Debug.Log(myAudioSource.clip.name);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        HandleAudio();
        myScene = SceneManager.GetActiveScene();
        myIndex = myScene.buildIndex;
    }

    /*Sets the audio to the desired game clip IF it isn't already set depending on which scene you are in.
     Makes the */
    void HandleAudio()
    {
        switch (myIndex)
        {
            case 5:
                NotDead();
                if (myAudioSource.clip != creditsClip)
                {
                    myAudioSource.clip = creditsClip;
                    AudioSourceInactive();
                }
                AudioSourceActive();
                break;
            case 4:
                NotDead();
                if (myAudioSource.clip != gameClip)
                {
                    myAudioSource.clip = gameClip;
                    AudioSourceInactive();
                }
                AudioSourceActive();
                break;
            case 3:
                NotDead();
                if (myAudioSource.clip != secondClip)
                {
                    myAudioSource.clip = secondClip;
                    AudioSourceInactive();
                }
                AudioSourceActive();
                break;
            case 2:
                NotDead();
                if (myAudioSource.clip != secondClip)
                {
                    myAudioSource.clip = secondClip;
                    AudioSourceInactive();
                }
                AudioSourceActive();
                break;
            case 1:
                NotDead();
                if (myAudioSource.clip != menuClip)
                {
                    myAudioSource.clip = menuClip;
                    AudioSourceInactive();
                }
                AudioSourceActive();
                break;
            case 0:
                NotDead();
                if (myAudioSource.clip != menuClip)
                {
                    myAudioSource.clip = menuClip;
                    AudioSourceInactive();
                }
                AudioSourceActive();
                break;
            default:
                break;
        }
    }

    void NotDead()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Play()
    {
        myAudioSource.Play();
    }

    void AudioSourceActive()
    {
        myAudioSource.enabled = true;
    }

    void AudioSourceInactive()
    {
        myAudioSource.enabled = false;
    }

}
