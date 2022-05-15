using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls: MonoBehaviour
{
    public Animator playerAnim;

    private float speed = 10.0f;
    private float turnSpeed = 150.0f;
    private float horizontalInput;
    private float forwardInput;
    public bool death;
    private int randomNum;
    public int maxHealth = 5;
    public int currentHealth;

    private HealthBar healthBar;

    private GameObject enemy;
    public GameObject healthPotion;


    private void Start()
    {
        //finds the game objects, animators, and sets the health
        healthPotion = GameObject.FindGameObjectWithTag("Health");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        currentHealth = 2;
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //change player animations to current player animations
        
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            playerAnim.SetInteger("walk", 5);
            speed = 3.0f;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            playerAnim.SetInteger("walk", 6);
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
            GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * speed * forwardInput);

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            randomNum = Random.Range(1, 4);
            if(randomNum == 1)
            {
                playerAnim.SetInteger("thrust", 1);
                //stopAnimation("thrust");
               // playerAnim.SetInteger("stop", 6);
            }
            if (randomNum == 2)
            {
                playerAnim.SetInteger("vertSlash", 2);
                //stopAnimation("vertSlash");
                //playerAnim.SetInteger("stop", 6);
            }
            if (randomNum == 3)
            {
                playerAnim.SetInteger("horizSlash", 3);
               // stopAnimation("horizSlash");
                //playerAnim.SetInteger("stop", 6);
            }
        }
        

    }
    public void stopAnimation(string anim)
    {
        playerAnim.SetInteger(anim, 0);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Health")) 
        {
            currentHealth++;
            Destroy(healthPotion);
        }
      
    }
}
