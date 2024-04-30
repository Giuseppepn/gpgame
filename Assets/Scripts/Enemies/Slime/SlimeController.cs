using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SlimeController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveDir;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.deltaTime));

    }

    public void MoveTo(Vector2 pos)
    {
        moveDir = pos;
    }


}
