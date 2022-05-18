using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscreen : MonoBehaviour
{

    // Start is called before the first frame update
    public AudioClip startMenu;
    public AudioSource source;
    void Start()
    {
        source.PlayOneShot(startMenu, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
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
