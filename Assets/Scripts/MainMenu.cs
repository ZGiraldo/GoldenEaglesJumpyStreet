using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject howToPanel = null;

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("JumpyStreet");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnClickMenuButton()//on game over and pause panels
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickHowToButton()//on main menu
    {
        howToPanel.SetActive(true);
    }

    public void OnClickCloseButton()//on main menu how to panel
    {
        howToPanel.SetActive(false);
    }
}
