using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyController : PlayerMovement
{
    Rigidbody2D myRB2;
    void Start()
    {
        myRB2 = GetComponent<Rigidbody2D>();
        ChangeDirection("right");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ChangeDirection(string direction)
    {
        switch (direction)
        {
            case "up":
            case "Up":
            case "UP":
                myRB2.velocity = speed * Vector2.up;
                break;
            case "down":
            case "Down":
            case "DOWN":
                myRB2.velocity = speed * Vector2.down;
                break;
            case "right":
            case "Right":
            case "RIGHT":
                myRB2.velocity = speed * Vector2.right;
                break;
            case "left":
            case "Left":
            case "LEFT":
                myRB2.velocity = speed * Vector2.left;
                break;
        }
    }
}
