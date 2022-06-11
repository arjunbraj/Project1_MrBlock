using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigid_body2D;
    public GameObject gameWonPanel;
    
    private float speed = 0;
    private float maxspeed = 5;
    private float acceleration = 10;
    private float deceleration = 10;

    private bool isGameWon = false;

    void Update()
    {
        if (isGameWon == true)
            return;

        if(Input.GetAxis("Horizontal") > 0 && speed < maxspeed) //right
        {
            speed = speed + acceleration * Time.deltaTime;
            rigid_body2D.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0 && speed > -maxspeed) //left
        {
            speed = speed - acceleration * Time.deltaTime;
            rigid_body2D.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0 && speed < maxspeed) //up
        {
            speed = speed + acceleration * Time.deltaTime;
            rigid_body2D.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0 && speed > -maxspeed) //down
        {
            speed = speed - acceleration * Time.deltaTime;
            rigid_body2D.velocity = new Vector2(0f, speed);
        }
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) //stop
        {
            rigid_body2D.velocity = new Vector2(0f, 0f);
        }
        if(Input.GetKey("space"))
        {
            if (speed > deceleration * Time.deltaTime)
                speed = speed - deceleration * Time.deltaTime;
            else if (speed < -deceleration * Time.deltaTime)
                speed = speed + deceleration * Time.deltaTime;
            else
                speed = 0;
                
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "door")
        {
            Debug.Log("Level Completed!");
            gameWonPanel.SetActive(true);
            isGameWon = true;
        }
    }
}
