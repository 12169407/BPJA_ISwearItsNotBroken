using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    GameObject player;
    GameObject enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= 206)
        {
            enemySpawner.GetComponent<enemyWaveGenerator>().readyToSpawn = true;
            Debug.Log("game has begun!!!!");
        }
    }
    
}
