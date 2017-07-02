using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public float timeLeft;

    public Text timeText;
    		
	void Update () {
        timeLeft -= Time.deltaTime;

        TimeSpan ts = TimeSpan.FromSeconds(timeLeft);                

        timeText.text = String.Format("{0:D1}:{1:D2}", ts.Minutes, ts.Seconds);
        
        if (timeLeft < 0)
        {
            timeText.color = Color.red;
            Debug.Log("Game over");
        }
	}
}
