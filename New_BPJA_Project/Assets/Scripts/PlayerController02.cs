using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController02 : MonoBehaviour
{
    // private vars for variables
    private float speed = 50.0f;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // move the vehicle forward based on verticle input
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        }

        // rotate the vehicle based on horizontalInput

        if (Input.GetKey("a") || Input.GetKey("d"))
            {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            }

    }
}