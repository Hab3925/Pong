using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            movement.y = 1;
        }else if (Input.GetKey("s"))
        {
            movement.y = -1;
        }else
        {
            movement.y = 0;
        }        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }

}
