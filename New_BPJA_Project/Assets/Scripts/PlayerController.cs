using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Mouse1))
        {
           // playerAnim.SetInteger("Walk", 1);
            speed = 3.0f;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Mouse1))
        {
            //playerAnim.SetInteger("Walk", 2);
            speed = 6.0f;
        }
        else
        {
            //playerAnim.SetInteger("Walk", 0);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //playerAnim.SetInteger("Attack", 1);
        }
        else
        {
            //playerAnim.SetInteger("Attack", 0);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //playerAnim.SetInteger("Defend", 1);
        }
        else
        {
            //playerAnim.SetInteger("Defend", 0);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (death)
        {
            //playerAnim.SetInteger("Death", 1);
        }
        if (!death)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //}
}
