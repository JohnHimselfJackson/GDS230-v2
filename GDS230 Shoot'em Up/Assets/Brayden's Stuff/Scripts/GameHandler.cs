using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameController gameController;
    public Text timerText;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        gameController = GetComponent<GameController>();
    }

    void Awake()
    {
        GameController.GameIsPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        timerText.text = "Time " + timer.ToString("F1");
    }
}
