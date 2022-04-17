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
        var numRecord = gameManager.GetComponent<GameManager>().RecordGetter().Item1;
        var delayRecord = gameManager.GetComponent<GameManager>().RecordGetter().Item2;

        // display record
        recordTxt.text = numRecord.ToString();
        if (delayRecord < int.MaxValue) { recordDelayTxt.text = delayRecord.ToString(); } // if that is not the first play of the player
        
        if (GameManager.BeatRecordIndicator)
        {
            // play record sound
            GetComponent<AudioSource>().Play();
            // play record animation
            scoreTxtDisplay.GetComponent<Animator>().SetTrigger("recordBreak");

            GameManager.BeatRecordIndicator = false;
        }
    }
}
