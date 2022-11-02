using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {
        scoreText.text = GameManager.score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
}
