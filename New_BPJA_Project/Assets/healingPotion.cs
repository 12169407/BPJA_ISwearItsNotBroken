using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingPotion : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            player.GetComponent<PlayerControls>().currentHealth += 3;
            player.GetComponent<PlayerControls>().healthBar.SetHealth(player.GetComponent<PlayerControls>().currentHealth);
            Destroy(gameObject);
        }
    }
}
