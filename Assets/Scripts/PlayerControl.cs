using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private bool isPlayer1;
    private Vector2 move = new Vector2(0, 0);
    private float speed = 5f;
    
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            move = new Vector2(ADMovement(), 0);
            rb2d.velocity = move * speed;
        }
        else
        {
            move = new Vector2(ArrowMovement(), 0);
            rb2d.velocity = move * speed;
        }
        
    }

    float ADMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            return -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            return 1f;
        }
        else
        {
            return 0;
        }
    }
    
    float ArrowMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return 1f;
        }
        else
        {
            return 0;
        }
    }
}
