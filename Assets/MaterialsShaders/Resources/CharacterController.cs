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
    private KeyCode Pause = KeyCode.Escape;

    [SerializeField] private int lives = 3;

    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;

    [SerializeField] private GameObject deathScreen;

    private bool _isPaused = false;

    [SerializeField] private GameObject _pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Pause) && !_isPaused)
        {
            Time.timeScale = 0.0f;
            _isPaused = true;
            _pauseMenu.SetActive(true);
        }

        else if(Input.GetKeyDown(Pause) && _isPaused)
        {
            Time.timeScale = 1.0f;
            _isPaused = false;
            _pauseMenu.SetActive(false);
        }

        CheckCameraBounds();

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

    void CheckCameraBounds()
    {
        if(transform.position.y <= -22)
        {
            transform.position = new Vector2(0, 0);
            Hurt();
        }
    }

    void Hurt()
    {
        lives--;

        if(lives < 3)
        {
            heart3.SetActive(false);
        }
        if(lives < 2)
        {
            heart2.SetActive(false);
        }
        if(lives < 1)
        {
            heart1.SetActive(false);
        }

        // Player dies
        if(lives <= 0)
        {
            Debug.Log("Dead :(");
            deathScreen.SetActive(true);
        }
    }

    public void ResetGame()
    {
        // Resst lives
        lives = 3;

        // Reset UI
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);

        deathScreen.SetActive(false);

        // Reset play pos
        transform.position = new Vector2(0, 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Hazard")
        {
            Hurt();
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
        _isPaused = false;
        _pauseMenu.SetActive(false);
    }
}
