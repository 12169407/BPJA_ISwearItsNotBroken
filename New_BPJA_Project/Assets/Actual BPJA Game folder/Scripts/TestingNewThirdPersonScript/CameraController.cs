using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool zoom = false;
    private float Baseangle = 0;
    private float angle = 35;
    private Vector3 y = new Vector3(0, 1, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (zoom)
        {
            transform.localPosition = new Vector3(0, 1.5f, 0.2f);
        }
        else
        {
            transform.localPosition = new Vector3(0, 6.26f, -10.4f);
        }
    }
}
