using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 245; // 4 minutes and 5 seconds
    public float timer; // Separate timer variable
    int minutes;
    int  seconds;

    [SerializeField] Text secondsText;
    [SerializeField] Text minutesText;

    void Start()
    {
        timer = totalTime; // Initialize timer to total time
        UpdateTimer();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            //Debug.Log(timer);

            // Ensure timer doesn't go below 0
            if (timer < 0)
            {
                timer = 0;
                // Handle timer completion here if needed
            }
            minutes = Mathf.FloorToInt(timer / 60);
            seconds = Mathf.FloorToInt(timer % 60);//we need to round down because an error happens when reaching a close number to 60 like 59.9999 
            //Debug.Log( seconds );
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        // Update UI text
        secondsText.text = seconds.ToString("00");
        minutesText.text = minutes.ToString("00");
    }
}
