using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public states myState;
    public GameObject pausePanel;
    public Transform myButton;

    UIBehaviour myBehaviour;

    public enum states
    {
        Paused,
        Unpaused
    }

    void Start()
    {
        myBehaviour = GetComponent<UIBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            PauseHandle();
        }
    }

    void PauseHandle()
    {
        switch (myState)
        {
            case states.Paused:
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                break;
            case states.Unpaused:
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
                break;
            default:
                Debug.Log("REEEEE");
                break;
        }
    }

    public void Pause()
    {
        GameIsPaused = true;
        myState = states.Paused;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        GameIsPaused = false;
        myState = states.Unpaused;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        myBehaviour.Smally(myButton);
    }
}
