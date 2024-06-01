using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    public Text healthText; 
    private PlayerHealth playerHealth;

    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        if (playerHealth == null)
        {
            FindPlayer();
        }

        if (playerHealth != null)
        {
            healthText.text = "HP: " + playerHealth.GetHP().ToString();
        }
        else
        {
            Debug.LogError("PlayerHealth reference is null in HPDisplay script.");
        }
    }

    void FindPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }
}
