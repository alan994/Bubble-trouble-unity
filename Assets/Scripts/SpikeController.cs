using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {

    public static bool IsActive;
    public float spikeSpeed;
    public Transform player;

    	
	void Start () {
        IsActive = false;
	}
	
	
	void Update () {
        if (GameController.Instance.GameIsFinished)
        {
            Destroy(this.gameObject);
            return;
        }
        if (Input.GetButtonDown(NameHelper.ButtonFireOne))
        {
            IsActive = true;
        }

        if (IsActive)
        {
            DoProgress();
        }
        else
        {
            StartFireing();
        }
	}

    private void StartFireing()
    {
        transform.position = player.position;
        transform.localScale = new Vector3(1f, 0f, 1f);
    }

    private void DoProgress()
    {
        transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * spikeSpeed;
    }
}
