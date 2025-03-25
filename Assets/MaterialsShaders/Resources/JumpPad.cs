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
        Rigidbody2D otherRB = collision.gameObject.GetComponent<Rigidbody2D>();

        if(!otherRB)
        {
            return;
        }
        
        otherRB.velocity = otherRB.velocity + jumpForce;
        audioSrc.Play();
    }
}
