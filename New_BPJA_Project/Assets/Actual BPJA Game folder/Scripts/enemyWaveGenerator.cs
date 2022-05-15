using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWaveGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnDelay = 5;
    private float interval = 2.0f;
    private float spawnNum;
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
        if(spawnNum >= 15)
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
