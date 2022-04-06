using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestRecord : MonoBehaviour
{
    public Text recordTxt;
    private GameObject gameManager;
    public GameObject scoreTxtDisplay;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");

        // display record
        recordTxt.text = gameManager.GetComponent<GameManager>().RecordGetter().ToString();
        
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
