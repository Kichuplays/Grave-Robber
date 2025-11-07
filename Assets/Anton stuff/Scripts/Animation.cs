using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Animation : MonoBehaviour
{
    //Anton K, Movement delen av skripten är gjord av Hannes

    public Animator anim;
    public float moveSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool isFacingRight = true;
    private bool isGrounded = false;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //if player på marken
        float moveDirection = Input.GetAxis("Horizontal"); //if player kollar horizontellt
        {
            Move(moveDirection);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }
            if (Input.GetKey(KeyCode.D)) //Anton K, gör så att animationen spelar när knappen blir nertryckt
            {
                
                anim.Play("Run_Animation");
                
            }
            else if (Input.GetKeyUp(KeyCode.D)) //Anton K, gör så att Run animationen slutar spela och går tillbaka till Idle när knappen slutar blir tryckt
            {
                anim.Play("Idle_Animation");
            }
            if (Input.GetKey(KeyCode.A)) 
            {

                anim.Play("RunLeft_Animation");

            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                anim.Play("Idle_Animation");
            }
        }
    }

    public void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}