using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverScoreText;
    public Text highscoreText;

    public GameObject gameOverUI;

    private float timeSurvivedInSeconds = 0;
    private float timeSurvivedInMinutes = 0;
    private float timer = 0;

    private string timeText;

    private bool startMinuteCounting = false;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetString("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        timeSurvivedInSeconds += Time.deltaTime;
        timer += Time.deltaTime;

        if(timeSurvivedInSeconds > 60)
        {
            timeSurvivedInMinutes += 1;
            timeSurvivedInSeconds = 0;
            startMinuteCounting = true;
        }

        timeText = startMinuteCounting == false ? timeSurvivedInSeconds.ToString("0.0") : timeSurvivedInMinutes.ToString("0") + " : " + timeSurvivedInSeconds.ToString("0.0");
        string timerText = timer.ToString("0.0");

        scoreText.text = timeText;
        gameOverScoreText.text = "Score: " + scoreText.text;
        highscoreText.text = "Highscore: " + PlayerPrefs.GetString("highscore");


        if(float.Parse(timerText) > PlayerPrefs.GetFloat("tempHighscore", 0))
        {
            PlayerPrefs.SetString("highscore", scoreText.text);
            PlayerPrefs.SetFloat("tempHighscore", float.Parse(timerText));
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
