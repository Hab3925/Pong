  
  
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    public float speedScaling = 12.0f;
    private int P1score;
    private int P2score;
    public Text Score;
    private bool paused = true;
    public Text pause;
    private bool done = false;

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
        if (!paused)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "P1" || collision.gameObject.name == "P2")
        {
            movement.x = -movement.x;
            movement.y = collision.relativeVelocity.y / speedScaling;
        }else if(collision.gameObject.name == "WallTop" || collision.gameObject.name == "WallBot")
        {
            movement.y = -movement.y;
        }
    }


    void Update()
    {
        if (Input.GetKey("space"))
        {
            if (done) return;
            if (paused) paused = false;
            pause.text = "";
        }

        if (Input.GetKeyDown("escape"))
        {
            if (!paused)
            {
                paused = true;
                pause.text = "Paused. \n\nContinue (space) \n\nExit (esc)";
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (transform.position.x >= 12)
        {
            transform.position = new Vector3(0, 0, 1);
            P1score += 1;
            movement.y -= movement.y + 1;
        }
        else if (transform.position.x <= -12)
        {
            transform.position = new Vector3(0, 0, 1);
            P2score += 1;
            movement.y -= movement.y + 1;
        }

        Score.text = "Player 1: " + P1score + "                                              Player 2: " + P2score;

        if(P1score >= 10)
        {
            Score.text = "Player 1 won!";
            pause.text = "Exit (esc)";
            paused = true;
            done = true;
        }
        if(P2score >= 10)
        {
            Score.text = "Player 2 won!";
            pause.text = "Exit (esc)";
            paused = true;
            done = true;
        }
    }
}