using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeV2Controller : MonoBehaviour
{
    private Rigidbody2D rb; 
    private Transform target;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindPlayer();
    }

    void Update()
    {
        if(target == null)
        {
            FindPlayer();
        }
        Vector2 direction = (target.position - transform.position).normalized; 
        rb.velocity = direction * speed; 
    }

    void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
