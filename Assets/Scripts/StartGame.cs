using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public static string username;


    public void LoadScene()
    {
        InputField input = GameObject.Find("InputUsername").GetComponent<InputField>();
        username = input.text;
        SceneManager.LoadScene(1);
        Debug.Log(username);
    }
}
