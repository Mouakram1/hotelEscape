
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 7f;

    public KeyCode L = KeyCode.LeftArrow;
    public KeyCode R = KeyCode.RightArrow;
    public KeyCode U = KeyCode.UpArrow;
    public KeyCode D = KeyCode.DownArrow;

    void Start()
    {
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

        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        GetComponent<Rigidbody2D>().velocity = movement * moveSpeed;

        if (horizontal < 0)
        {
            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontal > 0)
        {
            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
