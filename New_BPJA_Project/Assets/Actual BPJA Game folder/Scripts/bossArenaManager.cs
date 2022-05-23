using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class bossArenaManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject boss;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerControls>().currentHealth <= 0)
        {
            SceneManager.LoadScene("dead");
        }
        else if(boss.GetComponent<bossController>().hp <= 0)
        {

        }
    }
}
