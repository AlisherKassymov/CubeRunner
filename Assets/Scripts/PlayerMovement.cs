using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the RigidBody component 
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float upwardForce = 5f;


    // Update is called once per frame
    //Used fixed update to work with physics
    void FixedUpdate()
    {
        //Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            //Add force to the right
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            //Add force to the left
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0,upwardForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0,-upwardForce*Time.deltaTime , 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
