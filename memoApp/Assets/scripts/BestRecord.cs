using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestRecord : MonoBehaviour
{
    public Text recordTxt;
    public Text recordDelayTxt;
    private GameObject gameManager;
    public GameObject scoreTxtDisplay;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        
        // take records from game-manager
        var numRecord = gameManager.GetComponent<GameManager>().RecordGetter().Item1;
        var delayRecord = gameManager.GetComponent<GameManager>().RecordGetter().Item2;

        // display records
        recordTxt.text = numRecord.ToString();
        recordDelayTxt.text = delayRecord < int.MaxValue ? delayRecord.ToString() : "-";
        
        if (GameManager.BeatRecordIndicator)
        {
            // play record sound
            GetComponent<AudioSource>().Play();
            // play record animation
            scoreTxtDisplay.GetComponent<Animator>().SetTrigger("recordBreak");

            GameManager.BeatRecordIndicator = false;
        }
    }

    public void DisplayRecords()
    {
        recordTxt.text = "0";
        recordDelayTxt.text = "-";
    }
}
