using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        tempPos = transform.position;
        transform.position = new Vector3(3.2f, -15.71f, 1587f);
    }

    // Update is called once per frame
    void Update()
    {
        tempPos.z -= 0.5f;
        transform.position = tempPos;
        
    }
    void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.collider.tag == "Player") ;
            {
                SceneManager.LoadScene("Menu");
            }
        }

}
