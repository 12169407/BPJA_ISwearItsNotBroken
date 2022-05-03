using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera02FollowPlayer02 : MonoBehaviour
{
    // Start is called before the first frame update
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
