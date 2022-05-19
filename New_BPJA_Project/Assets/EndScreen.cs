using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }


    IEnumerator endScreen()
    {
        yield return new WaitForSeconds(6);

        SceneManager.LoadScene("EndMenu");
    }
}
