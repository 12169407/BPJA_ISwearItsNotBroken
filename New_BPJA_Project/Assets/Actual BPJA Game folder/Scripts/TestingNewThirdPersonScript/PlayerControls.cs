using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls: MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 150.0f;
    private float horizontalInput;
    private float forwardInput;
    private Animator playerAnim;
    public bool death;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //change player animations to current player animations

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            //playerAnim.SetInteger("Walk", 1);
            speed = 3.0f;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            //playerAnim.SetInteger("Run", 2);
            speed = 6.0f;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (death)
        {
            //playerAnim.SetInteger("Death", 1);
        }
        if (!death)
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * speed * forwardInput);

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }

    }
}
