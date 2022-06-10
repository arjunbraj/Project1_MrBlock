using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigid_body2D;
    
    public float speed;
    

    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0) //right
        {
            rigid_body2D.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0) //left
        {
            rigid_body2D.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0) //up
        {
            rigid_body2D.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0) //down
        {
            rigid_body2D.velocity = new Vector2(0f, -speed);
        }
        else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) //stop
        {
            rigid_body2D.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "door")
            Debug.Log("Level Completed!");
    }
}
