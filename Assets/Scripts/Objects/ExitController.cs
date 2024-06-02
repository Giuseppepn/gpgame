using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth healthScript = collision.gameObject.GetComponent<PlayerHealth>();
            PlayerPrefs.SetInt("HP", healthScript.GetHP());
            SceneManager.LoadScene(sceneToLoad);
            SceneController.Instance.SetTransitionName(sceneTransitionName);
        }
    }

}
