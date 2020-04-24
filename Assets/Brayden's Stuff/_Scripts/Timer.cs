using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeUp();
    }

    void TimeUp()
    {
        time = time + Time.deltaTime;
        timerText.text = "Time: " + time.ToString();
    }
}
