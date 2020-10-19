using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] ProceduralGenerator procedGenerator = null;
    [SerializeField] Text playerScoreText = null;
    [SerializeField] Text highScoreText = null;
    [SerializeField] Text finalScoreText = null;
    [SerializeField] Text finalHighScoreText = null;
    [SerializeField] GameObject gameOverPanel = null;
    [SerializeField] GameObject pauseMenu = null;

    public int score = -1;
    private int dividerCounter = -3;

    void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        pauseMenu.SetActive(false);
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))//press 0 in the top number line to reset highscore
        {
            PlayerPrefs.SetInt("Highscore", 0);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
        }

        PauseGame();
    }

    void PauseGame()//press esc to pause. Press again to resume
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Terrain" || other.tag == "Divider")
        {
            AddScore();
            other.enabled = false;
        }

        if(other.tag == "Divider")
        {
            if (dividerCounter > 0)
            {
                procedGenerator.TrackTerrain();
            }
            else
            {
                dividerCounter++;
            }

        }

        if(other.tag == "Death")
        {
            PlayerDeath();
        }
    }

    public void AddScore()
    {
        score++;
        playerScoreText.text = "Score: " + score.ToString();
        if(PlayerPrefs.GetInt("Highscore") < score)//set new high score if current highscore is lower than current game score
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
        }
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + score;
        finalHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();

        FindObjectOfType<AudioManager>().Play("Death");
    }
}
