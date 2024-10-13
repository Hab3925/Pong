using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallBehaviourMenu : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    public float speedScaling = 12.0f;

    Vector2 movement;

    void Start()
    {
        movement.y = Random.Range(-1, 2);
        movement.x = Random.Range(-1, 2);

        while (movement.x == 0)
        {
            movement.x = Random.Range(-1, 2);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "P1" || collision.gameObject.name == "P2")
        {
            movement.x = -movement.x;
            movement.y = collision.relativeVelocity.y / speedScaling;
        }
        else if (collision.gameObject.name == "WallTop" || collision.gameObject.name == "WallBot")
        {
            movement.y = -movement.y;
        }
    }


    void Update()
    {
        if (transform.position.x >= 12)
        {
            transform.position = new Vector3(0, 0, 1);
            movement.y -= movement.y + 1;
        }
        else if (transform.position.x <= -12)
        {
            transform.position = new Vector3(0, 0, 1);
            movement.y -= movement.y + 1;
        }
    }
}