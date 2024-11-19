using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    private Transform shootPosition;

    private AudioSource audioSrc;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Mouse1) ){
            Shoot();
            audioSrc.Play();
        }
    }

    void Shoot(){
        shootPosition = GetComponent<Transform>();
        Vector3 shootDirection = shootPosition.position;
        Quaternion shootAngle = shootPosition.localRotation;
        // make the bullet and give it velocity
        GameObject newBullet = Instantiate(bullet, shootDirection, shootAngle);

        // Apply velocity
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed, rb.velocity.y);
    }
}
