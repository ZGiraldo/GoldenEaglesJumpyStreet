using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void OnClickPlayButton()//launch main game scene
    {
        SceneManager.LoadScene("JumpyStreet");
    }

    public void OnClickMenuButton()//on game over and pause panels
    {
        SceneManager.LoadScene("MainMenu");
    }
}
