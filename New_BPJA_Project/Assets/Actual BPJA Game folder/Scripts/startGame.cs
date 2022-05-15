using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject.Find("enemyWaveSpawner").GetComponent<enemyWaveGenerator>().readyToSpawn = true;
            Debug.Log("game has begun!!!!");
        }
    }
}
