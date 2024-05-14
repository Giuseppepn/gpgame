using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Build.Content;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public static int maxHP = 3;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private Color damageColor;
    [SerializeField] private float restoreDefaultColorTime = .2f;
    public GameObject timerObject;
    private Color defaultColor;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;
    private int currentHP;
    private bool canTakeDamage = true;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        defaultColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if((collision.gameObject.name == "Slime" || collision.gameObject.name == "SlimeV2") && canTakeDamage)
        {
            TakeDamage(1);
            StartCoroutine(DamageAnimation());
        }
    }

    private IEnumerator DamageAnimation()
    {
        spriteRenderer.color = new Color(0.61f, 0.01f, 0.01f);
        yield return new WaitForSeconds(restoreDefaultColorTime);
        spriteRenderer.color = defaultColor;

    }

    private void TakeDamage(int i)
    {
        canTakeDamage = false;
        currentHP -= i;
        StartCoroutine(PlayerRecover());

            if(currentHP == 0)
            {
            TimerScript timerScript = timerObject.GetComponent<TimerScript>();
            if (timerScript != null)
            {
                timerScript.StopTimer();
            }
            Debug.Log("Il player è morto! aveva con se monete: " + playerController.GetCoins() + " Tempo: " + timerScript.timer);
            StartCoroutine(Upload());
            SceneManager.LoadScene(5);
        }
    }

    private IEnumerator PlayerRecover()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    [System.Serializable]
    public class ScoreData
    {
        public string username;
        public int coins;
    }

    IEnumerator Upload()
    {
        string username = StartGame.username;
        int coins = playerController.GetCoins();

        // Create a ScoreData object
        ScoreData scoreData = new ScoreData();
        scoreData.username = username;
        scoreData.coins = coins;

        // Convert ScoreData object to JSON string
        string jsonData = JsonUtility.ToJson(scoreData);

        // Set request headers
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        UnityWebRequest www = new UnityWebRequest("http://localhost:3000/api/score", "POST");
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.SetRequestHeader("Content-Type", "application/json");

        // Make the POST request
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Success!");
        }
        else
        {
            Debug.LogError("Error: " + www.error);
        }
    }



}
