using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tutorialScript : MonoBehaviour
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
            SceneManager.LoadScene("StartMenu");
        }
    }

}