using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraScript : MonoBehaviour
{
    private float lowLimit = 0.0f;
    private float highLimit = 85.0f;

    public GameObject cam;
    public float fllwDist = 5.0f;
    public float mouseSensitivityX = 4.0f;
    public float mouseSensitivityY = 2.0f;
    public float heightOffset = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        cam.transform.forward = gameObject.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Vector2 camMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            cam.transform.position = gameObject.transform.position + new Vector3(0, heightOffset, 0);
            cam.transform.eulerAngles = new Vector3(Mathf.Clamp(cam.transform.eulerAngles.x - camMovement.y * mouseSensitivityY, lowLimit, highLimit), cam.transform.eulerAngles.y + camMovement.x * mouseSensitivityX, 0);

            cam.transform.position -= cam.transform.forward * fllwDist;
        }
        
    }
}
