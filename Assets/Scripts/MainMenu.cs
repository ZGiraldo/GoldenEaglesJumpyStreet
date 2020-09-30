using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("JumpyStreet");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
