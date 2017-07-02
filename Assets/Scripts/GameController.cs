using System;
using System.Collections;
using System.Collections.Generic;
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

    public Button tryAgain;
    public Button returnToMainMenu;

    private List<GameObject> balls;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

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
        balls.Add(ball);
    }

    private void CheckIfGameIsFinished()
    {
        if(balls.Count == 0)
        {
            GameIsFinished = true;
            WinText.gameObject.SetActive(true);

        }
    }

    public void ContinueToNextLevel()
    {
        //switch (SceneManager.GetActiveScene().buildIndex)
        //{
        //    case NameHelper.SceneLevelOneIndex:
        //        break;
        //    case NameHelper.SceneLevelTwoIndex:
        //        break;
        //    case NameHelper.SceneLevelOneIndex:
        //        break;

        //}
    }

    public void RemoveBallFromTracking(GameObject ball)
    {
        balls.Remove(ball);
    }

}
