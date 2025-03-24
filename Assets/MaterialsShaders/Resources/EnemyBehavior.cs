using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float speedIncrement = 0.1f;

    [SerializeField]
    private float speedLimit = 10.0f;

    private Rigidbody2D rb;

    private Transform playerLocation;

    private Transform enemyLocation;

    private int health = 2;

    private int damage = 1;

    [SerializeField]
    private float jumpOnWallForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        enemyLocation = gameObject.GetComponent<Transform>();
        playerLocation = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(beginningSpeed, rb.velocity.y);
        if(playerLocation.position.x - enemyLocation.position.x > 0 && rb.velocity.x < speedLimit){
            rb.velocity = new Vector2(rb.velocity.x + speedIncrement, rb.velocity.y);
        }else if(playerLocation.position.x - enemyLocation.position.x < 0 && rb.velocity.x > -speedLimit){
            rb.velocity = new Vector2(rb.velocity.x + -speedIncrement, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.layer == 6 || col.gameObject.tag == "Player"){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpOnWallForce);
        }
    }

    public void TakeDamage(){
        health -= damage;
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
}