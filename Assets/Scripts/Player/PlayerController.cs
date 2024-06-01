using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] public static int coins = 0;
    private PlayerInputs playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    public GameObject timerObject;


    private void Awake()
    {
        playerControls = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
       
        PlayerInput();
        if(coins == 6)
        {
            SceneManager.LoadScene(4);
            StartCoroutine(Upload());
        }
    }

    private void FixedUpdate()
    {
        Move();
        checkDirection();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }


    private void checkDirection()
    {
        if (movement.x < 0)
        {
            
            mySpriteRender.flipX = true;
        }
        else if (movement.x > 0)
        {
            
            mySpriteRender.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISIONE! con: " + collision.gameObject.name);
        if (collision.gameObject.name == "Coin(Clone)")
        {
            coins++;
            Debug.Log("Le monete sono: " + coins);
            Destroy(collision.gameObject);
        }
    }

    public int GetCoins()
    {
        return coins;
    }


    [System.Serializable]
    public class ScoreData
    {
        public string username;
        public float time;
    }

    IEnumerator Upload()
    {
        TimerScript timerScript = timerObject.GetComponent<TimerScript>();
        string username = StartGame.username;
        if(username == null)
        {
            username = "Anonymous";
        }
        float time = timerScript.GetTime();

        // Create a ScoreData object
        ScoreData scoreData = new ScoreData();
        scoreData.username = username;
        scoreData.time = time;

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
