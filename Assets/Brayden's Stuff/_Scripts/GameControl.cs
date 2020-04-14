using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    //A reference to our audiosource & clips.
    public AudioSource myAudioSource;
    public AudioClip[] myClips;


    //A reference to our character sprites & sprite renderers in game.
    public SpriteRenderer[] characterSpriteRenderers;
    public Sprite[] characterSprites;

    //Our paused boolean.
    public bool GameIsPaused = false;
    public bool GameCommence = false;
    
    //A reference to our pause states.
    public pauseState pauseStates;
    
    //Our Pause Panel.
    public GameObject pausePanel;
    
    //Our play & pause state enums.
    public enum playState
    {
        Menu,
        Play
    }

    public enum pauseState
    {
        Paused,
        Unpaused
    }

    public void Update()
    {
        PauseHandle();
    }

    //Handles our pausing & resuming of the game.
    void PauseHandle()
    {
        switch (pauseStates)
        {
            case pauseState.Paused:
                Time.timeScale = 0f;
                break;
            case pauseState.Unpaused:
                Time.timeScale = 1f;
                break;
            default:
                Debug.Log("REEEEE");
                break;
        }
    }

    public void Pause()
    {
        GameIsPaused = true;
        pauseStates = pauseState.Paused;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        GameIsPaused = false;
        pauseStates = pauseState.Unpaused;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
}
