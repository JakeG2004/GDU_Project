using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    private Vector3 shootPosition;

    private AudioSource audioSrc;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed = 30.0f;

    Vector3 mousePos;
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        //audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Mouse1) ){
            Shoot();
            //audioSrc.Play();
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = transform.parent.transform.position;

        shootPosition = -3 * Vector3.Normalize(playerPos - mousePos) + playerPos;
        transform.position = shootPosition;
    }

    void Shoot(){
        Vector3 newVel = Vector3.Normalize(playerPos - mousePos);
        Vector3 shootDirection = mousePos;
        Quaternion shootAngle = Quaternion.LookRotation(Vector3.Normalize(playerPos - mousePos), new Vector3(0, 0, 1));
        // make the bullet and give it velocity
        GameObject newBullet = Instantiate(bullet, shootPosition, shootAngle);

        // Apply velocity
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1 * bulletSpeed * newVel.x, -1 * bulletSpeed * newVel.y);
    }
}
