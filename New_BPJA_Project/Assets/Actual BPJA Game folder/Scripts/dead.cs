using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dead : MonoBehaviour
{

    // Start is called before the first frame update
    public AudioClip deadMenu;
    public AudioSource source;
    void Start()
    {
        source.PlayOneShot(deadMenu, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void OpenOptions()
    {

    }
    public void ClosedOptions()
    {

    }
    public void QuitGame()
    {

    }
}
