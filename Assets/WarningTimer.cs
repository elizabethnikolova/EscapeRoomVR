using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTimer : MonoBehaviour
{
    public float displayTime = 3;
    private float timeRemaining;
    public bool timerIsRunning = false;

    void Start()
    {
        timeRemaining = displayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                GameObject canvas = GameObject.Find("Canvas");
                canvas.gameObject.transform.Find("MonitorNotConnectedWarning").gameObject.SetActive(false);
                timeRemaining = displayTime;
                timerIsRunning = false;
            }
        }
    }
}
