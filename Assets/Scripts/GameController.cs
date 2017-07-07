using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;



    public float timeLeft;
    public bool GameIsFinished = false;

    public Text timeText;
    public Text gameOwerText;
    public Text WinText;
    public Text timeIsUp;

    public Button tryAgain;
    public Button returnToMainMenu;
    public Button continueToNextLevel;

    private List<GameObject> balls;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        balls = new List<GameObject>();
        Instance = this;
    }


    void Update()
    {
        if (GameIsFinished)
        {
            return;
        }

        timeLeft -= Time.deltaTime;

        TimeSpan ts = TimeSpan.FromSeconds(timeLeft);

        timeText.text = String.Format("{0:D1}:{1:D2}", ts.Minutes, ts.Seconds);

        if (timeLeft < 0)
        {
            timeText.color = Color.red;
            timeIsUp.gameObject.SetActive(true);
            GameOwer();
        }


    }
    public void GameOwer()
    {
        this.GameIsFinished = true;
        gameOwerText.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        returnToMainMenu.gameObject.SetActive(true);
        WinText.gameObject.SetActive(false);
    }


    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    


    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(NameHelper.SceneMainManuIndex);
    }


    public void AddBallToTracking(GameObject ball)
    {
        if (balls.FirstOrDefault(x => x == ball) == null)
        {
            balls.Add(ball);
        }
        CheckIfGameIsFinished();
    }

    private void CheckIfGameIsFinished()
    {
        if(balls.Count == 0 && !GameIsFinished)
        {
            GameIsFinished = true;
            WinText.gameObject.SetActive(true);
            tryAgain.gameObject.SetActive(true);
            returnToMainMenu.gameObject.SetActive(true);
            continueToNextLevel.gameObject.SetActive(true);
        }
    }

    public void ContinueToNextLevel()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case NameHelper.SceneLevelOneIndex:
                SceneManager.LoadScene(NameHelper.SceneLevelTwoIndex);
                break;
            case NameHelper.SceneLevelTwoIndex:
                SceneManager.LoadScene(NameHelper.SceneLevelThreeIndex);
                break;
            case NameHelper.SceneLevelThreeIndex:
                SceneManager.LoadScene(NameHelper.SceneGameFinishedIndex);
                break;
        }
    }

    public void RemoveBallFromTracking(GameObject ball)
    {
        balls.Remove(ball);
        CheckIfGameIsFinished();
    }

}
