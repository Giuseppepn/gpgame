using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


}
