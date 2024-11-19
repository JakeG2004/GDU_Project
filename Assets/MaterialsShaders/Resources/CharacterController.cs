using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float acceleration = 1f;
    public float drag = 20;
    public float jumpForce = 10f;

    private bool _canDoubleJump = false;

    private bool _isGrounded = true;
    public float groundCheckRadius = 0.2f;
    public Transform groundPoint;
    public LayerMask groundLayer;

    public Rigidbody2D rb;

    public int numJumps = 0;

    public KeyCode Crouch = KeyCode.S;

    // Update is called once per frame
    void Update()
    {
        //check for ground
        _isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundCheckRadius, groundLayer);

        if(_isGrounded)
        {
            _canDoubleJump = true;
            numJumps = 0;
        }

        //create new velocity vector
        Vector2 newVelocity = rb.velocity;

        //handle jumps
        if(Input.GetButtonDown("Jump") && (_isGrounded || _canDoubleJump) && numJumps < 1)
        {
            newVelocity.y = jumpForce;
            numJumps++;
        }

        if(Input.GetKeyDown(Crouch))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);  
        }

        else if(Input.GetKeyUp(Crouch))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2.0f, transform.localScale.z); 
        }

        //get the direction of travel
        float moveInput = Input.GetAxisRaw("Horizontal");

        if(moveInput > 0)
        {
            newVelocity.x = maxSpeed;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        else if(moveInput < 0)
        {
            newVelocity.x = -1 * maxSpeed;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        //otherwise, decelerate the object
        else
        {
            newVelocity.x = Mathf.MoveTowards(rb.velocity.x, 0, drag * Time.deltaTime);
        }

        //assign the velocity
        rb.velocity = newVelocity;
    }
}
