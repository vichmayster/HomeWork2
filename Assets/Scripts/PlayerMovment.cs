using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    float input;
    bool directionRight = true;

    [Header("Movment")]
    [SerializeField] int speed;
    [SerializeField] int jumpForce;

    [Header("Collision with ground")]
    [SerializeField] float distanceToGround;
    [SerializeField] LayerMask ground;
    bool isGrounded;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        HandleCollision();
        HandleInput();
        HandleMovment();
        HandleAnimations();
        HandleFlip();
    }

    private void HandleInput()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, ground);
    }

    private void HandleMovment()
    {
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    private void HandleFlip()
    {
        if(rb.velocity.x < 0 && directionRight || rb.velocity.x > 0 && !directionRight)
            Flip();
        
    }
    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        directionRight = !directionRight;
    }
    private void HandleAnimations()
    {
        animator.SetBool("isMoving", rb.velocity.x != 0);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
       
    }
}
