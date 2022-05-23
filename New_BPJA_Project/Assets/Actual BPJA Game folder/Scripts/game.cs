using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    GameObject player;
    GameObject enemySpawner;
    GameObject portal;
    public AudioSource playerAudio;
    public AudioClip playerBkgrnd;
    // Start is called before the first frame update
    void Start()
    {
        portal = GameObject.FindGameObjectWithTag("Portal");
        portal.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            portal.SetActive(true);
            enemySpawner.GetComponent<enemyWaveGenerator>().readyToSpawn = true;
            playerAudio.Stop();
            playerAudio.PlayOneShot(playerBkgrnd, 1.0f);
        }
    }

}
