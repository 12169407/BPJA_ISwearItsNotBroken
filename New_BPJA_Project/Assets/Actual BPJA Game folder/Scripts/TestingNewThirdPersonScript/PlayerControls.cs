using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


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
    public int healthPoint;
    public int maxHealthPoint;


    public HealthBar healthBar;

    private GameObject enemy;
    //public TextMeshProUGUI scoreText;
    public AudioSource soundfx;
    public AudioClip swoosh1;
    public AudioClip swoosh2;
    public AudioClip swoosh3;
    public AudioClip chickenHurt;
    public TextMeshProUGUI healthPointsRemaining;


    private void Start()
    {
        //finds the game objects, animators, and sets the health
        //finds the game objects, animators, and sets the health
        UpdateHealthPoints(0);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        currentHealth = maxHealth;
        healthPoint = maxHealthPoint;
        playerAnim = GetComponent<Animator>();
        healthBar.SetHealth(maxHealth);
        UpdateHealthPoints(maxHealthPoint);
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
                soundfx.PlayOneShot(swoosh1, 1.0f);
                //stopAnimation("thrust");
               // playerAnim.SetInteger("stop", 6);
            }
            if (randomNum == 2)
            {
                playerAnim.SetInteger("vertSlash", 2);
                soundfx.PlayOneShot(swoosh3, 1.0f);
                //stopAnimation("vertSlash");
                //playerAnim.SetInteger("stop", 6);
            }
            if (randomNum == 3)
            {
                playerAnim.SetInteger("horizSlash", 3);
                soundfx.PlayOneShot(swoosh2, 1.0f);
                // stopAnimation("horizSlash");
                //playerAnim.SetInteger("stop", 6);
            }
        }
        if(Input.GetKey(KeyCode.Mouse1))
        {
            playerAnim.SetInteger("block",8);
        }
        else
        {
            playerAnim.SetInteger("block", 0);
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            healthPoint--;
            if(healthPoint >= 0)
            {
                UpdateHealthPoints(healthPoint);
                if (currentHealth + 3 > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                else
                {
                    currentHealth += 3;
                }
                healthBar.SetHealth(currentHealth);
            }
            
        }
    }
    public void stopAnimation(string anim)
    {
        playerAnim.SetInteger(anim, 0);

    }
    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.collider.CompareTag("Enemy"))
        {
            soundfx.PlayOneShot(chickenHurt,1.0f);
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            playerAnim.SetInteger("hit", 1);
        }
    }
    private void UpdateHealthPoints(int h)
    {
        healthPointsRemaining.text = "Health Points: " + h;
    }
}
