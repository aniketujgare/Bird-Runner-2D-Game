using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private Button restartButton;

    [SerializeField] private Text scoreText, pauseText;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score + " M";
        StartCoroutine(CountScore());
    }

    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.6f);
        score++;
        scoreText.text = score + " M";

        StartCoroutine(CountScore());
    }

    private void OnEnable()
    {
        PlayerDied.endGame += PlayerDiedEndTheGame;
    }
    private void OnDisable()
    {
        PlayerDied.endGame -= PlayerDiedEndTheGame;
    }
    void PlayerDiedEndTheGame()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        else
        {
            int highScore = PlayerPrefs.GetInt("Score");

            if (highScore < score)
            {
                PlayerPrefs.SetInt("Score", score);
            }
        }

        pauseText.text = "Game Over";
        pausePanel.SetActive(true);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() => RestartGame());
        Time.timeScale = 0f;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }
    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() => ResumeGame());
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        //SceneManager.LoadScene("GamePlay");
    }
}
