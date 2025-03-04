using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float beginningSpeed = 15.0f;

    private Rigidbody2D rb;

    private int health = 2;

    private int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(beginningSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.layer != 3){
            beginningSpeed = -beginningSpeed;
        }
    }

    public void TakeDamage(){
        health -= damage;
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
}