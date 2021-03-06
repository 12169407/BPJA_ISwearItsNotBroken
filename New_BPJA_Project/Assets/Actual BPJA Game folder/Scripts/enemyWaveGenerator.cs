using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemyWaveGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnDelay = 5;
    private float interval = 2.0f;
    private float spawnNum;
    public int spawnLimit;
    public bool readyToSpawn = false;
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnNum >= spawnLimit)
        {
            CancelInvoke();
        }
    }

    void Spawn()
    {
        Vector3 spwnloc = new Vector3(x,y,z);
        if(readyToSpawn)
        {
            Instantiate(enemyPrefab, spwnloc, enemyPrefab.transform.rotation);
            spawnNum++; 
        }
    }
}
