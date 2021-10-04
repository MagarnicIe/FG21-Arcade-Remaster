using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float JumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int doubleJump = 0; 
    public bool isGrounded;

    private bool canDoubleJump;
    

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
                Jump();
            canDoubleJump = true;
        }
        
        else if (canDoubleJump)

        {
            Jump();
            canDoubleJump = false;
        }
      // var movement = Input.GetAxisRaw("Horizontal");
      // transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

      // if (!Mathf.Approximately(0, movement))
      //     transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

    }

    private void FixedUpdate()
    {
        
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Jump()
    {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            // rb.velocity = Vector2.up * JumpForce;
        
       //if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
    }
    


}

