using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MyGameManager MyGameManager;
    public float speed = 1;

    private Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        ChangeDirection("right");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeDirection(string direction)
    {
        switch (direction)
        {
            case "up":
            case "Up":
            case "UP":
                myRB.velocity = speed * Vector2.up;
                break;
            case "down":
            case "Down":
            case "DOWN":
                myRB.velocity = speed * Vector2.down;
                break;
            case "right":
            case "Right":
            case "RIGHT":
                myRB.velocity = speed * Vector2.right;
                break;
            case "left":
            case "Left":
            case "LEFT":
                myRB.velocity = speed * Vector2.left;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Pickup":
                break;
        }
    }
}
