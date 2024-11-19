using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private Rigidbody2D playerRb;

    private AudioSource audioSrc;

    [SerializeField]
    private Vector2 jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("We are outside the if statement");
        if(collision.gameObject.name == "Player"){
            Debug.Log("We are in the if statement");
            playerRb.velocity = playerRb.velocity + jumpForce;
            audioSrc.Play();
        }
    }
}
