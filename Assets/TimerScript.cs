using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public bool timerIsOn = false;
    public float timer = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (timerIsOn)
        {
            timer += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        timerIsOn = true;
    }

    public void StopTimer()
    {
        timerIsOn= false;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
