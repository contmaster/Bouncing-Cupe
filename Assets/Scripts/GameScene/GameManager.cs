using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [Header("Pause Panel Settings")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    
    [Header("Delay Settings")]
    [SerializeField] private TextMeshProUGUI delayTimeText;
    [SerializeField] private TextMeshProUGUI getReadyText;
    [SerializeField] private TextMeshProUGUI gamePausedText;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject quitButton;

    private int delayTime = 3;

    public static int score = 0;

    private void Update()
    {
        scoreText.text = score.ToString();
        GetHighScore();
    }

    public void GetHighScore()
    {
        if (GameManager.score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", GameManager.score);
        }
    }

    public void PauseButton()
    {
        gamePausedText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        delayTimeText.gameObject.SetActive(false);
        getReadyText.gameObject.SetActive(false);
        replayButton.SetActive(true);
        quitButton.SetActive(true);

        pauseButton.SetActive(false);
        pausePanel.SetActive(true);

        Time.timeScale = 0;

        //observer design pattern
    }

    public void ContinueButton()
    {
        gamePausedText.gameObject.SetActive(false);
        continueButton.SetActive(false);
        delayTimeText.gameObject.SetActive(true);
        getReadyText.gameObject.SetActive(true);
        replayButton.SetActive(false);
        quitButton.SetActive(false);

        StartCoroutine(CountdownStart());
    }

    IEnumerator CountdownStart()
    {
        while (delayTime > 0)
        {
            delayTimeText.text = delayTime.ToString();

            yield return new WaitForSecondsRealtime(1);

            delayTime--;
        }

        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        delayTime = 3;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ReloadGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        score = 0;
    }
}
