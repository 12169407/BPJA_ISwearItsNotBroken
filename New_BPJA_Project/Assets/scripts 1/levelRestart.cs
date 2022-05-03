using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelRestart : MonoBehaviour
{
   public void restartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
