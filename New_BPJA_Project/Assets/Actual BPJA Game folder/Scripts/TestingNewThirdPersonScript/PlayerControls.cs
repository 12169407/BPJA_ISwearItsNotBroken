using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControls: MonoBehaviour
{
    private Animator playerAnim;

    private float speed = 10.0f;
    private float turnSpeed = 150.0f;
    private float horizontalInput;
    private float forwardInput;
    public bool death;
    private int randomNum;
    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    private GameObject enemy;
    public GameObject healthPotion;



    private void Start()
    {
        //finds the game objects, animators, and sets the health
        healthPotion = GameObject.FindGameObjectWithTag("Health");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        currentHealth = maxHealth;
        playerAnim = GetComponent<Animator>();
        healthBar.SetHealth(maxHealth);
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
        if (currentHealth <= 0)
        {
            death = true;
            SceneManager.LoadScene("Dead");
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
            healthBar.SetHealth(currentHealth);
            Destroy(healthPotion);
        }
      
        if (collision.collider.CompareTag("Enemy"))
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            playerAnim.SetInteger("hit", 1);
        }
    }
}
