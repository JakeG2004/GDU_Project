using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    private AudioSource audioSrc;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed = 30.0f;

    [SerializeField] private float _shootTime = 3.0f;
    private float curTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _shootTime = Random.Range(1.5f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        curTimer += Time.deltaTime;

        if(curTimer >= _shootTime)
        {
            SpawnObject();
            curTimer = 0.0f;
            _shootTime = Random.Range(1.5f, 3.5f);
        }
    }

    void SpawnObject(){
        Transform shootPosition = transform;
        Vector3 shootDirection = shootPosition.position;
        Quaternion shootAngle = shootPosition.localRotation;
        // make the bullet and give it velocity
        GameObject newBullet = Instantiate(bullet, shootDirection, shootAngle);

        // Apply velocity
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed, rb.velocity.y);
    }
}
