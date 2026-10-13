
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public KeyCode L = KeyCode.LeftArrow;
    public KeyCode R = KeyCode.RightArrow;
    public KeyCode U = KeyCode.UpArrow;
    public KeyCode D = KeyCode.DownArrow;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Top-down game
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(L))
        {
            horizontal = -1f;
        }

        if (Input.GetKey(R))
        {
            horizontal = 1f;
        }

        if (Input.GetKey(U))
        {
            vertical = 1f;
        }

        if (Input.GetKey(D))
        {
            vertical = -1f;
        }
        if (horizontal != 0)
        {
            vertical = 0;
        }

        movement = new Vector2(horizontal, vertical);
        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // if (horizontal < 0)
        // {
        //     if (GetComponent<SpriteRenderer>() != null)
        //         GetComponent<SpriteRenderer>().flipX = true;
        // }
        // else if (horizontal > 0)
        // {
        //     if (GetComponent<SpriteRenderer>() != null)
        //         GetComponent<SpriteRenderer>().flipX = false;
        // }
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
}
