using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //variables for the game object and camera offset (so it's right above the player)
    public GameObject player;
    private Vector3 offset = new Vector3(0, 6, -10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transforms camera position to follow the player
        transform.position = player.transform.position + offset;
    }
}
