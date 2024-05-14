using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public static string username;
    public static float timer;
    public GameObject timerObject;

    public void LoadScene()
    {
        if (username == null)
        {
            InputField input = GameObject.Find("InputUsername").GetComponent<InputField>();
            username = input.text;
        }
        TimerScript timerScript = timerObject.GetComponent<TimerScript>();
        if(timerScript != null)
        {
            timerScript.StartTimer();
        }
        SceneManager.LoadScene(1);
        Debug.Log(username);
    }

    public void ResetGame()
    {
        username = null;
        timer = 0;
        SceneManager.LoadScene(0);
    }

    public void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
    }
}
