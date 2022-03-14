using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class Randomize : MonoBehaviour
{
    private int currIndex = 0;
    private float readingTime = 1f;
    private Random rnd = new Random();
    private int randDig;
    private int digNum;
    private int Delay;
    private bool isDelaying = false;
    public GameObject digitTxt;
    private AudioSource currAS;

    private GameObject gameManager;

    public GameObject testButton;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        
        digNum = gameManager.GetComponent<GameManager>().DigNumGetter();
        Delay = gameManager.GetComponent<GameManager>().DelayGetter();
    }

    // Update is called once per frame
    void Update()
    {
        // suspension ?

        if (currIndex < digNum)
        {
            if (! isDelaying)
            {
                // generate random number
                randDig = rnd.Next(0, 9);
                // append to list
                gameManager.GetComponent<GameManager>().AddToRandomList(randDig);
                // display on screen
                digitTxt.GetComponent<Text>().text = randDig.ToString();
                // play sound
                GameObject.Find($"number {randDig} sound").GetComponent<AudioSource>().Play();
                // increase index
                currIndex++;
                // delay
                isDelaying = true;
                Invoke("EndDelay", readingTime + Delay);
            }
        }
        else
        {
            if (!isDelaying)
            {
                // number disappears
                digitTxt.GetComponent<Text>().text = "";
                // test button appears
                testButton.SetActive(true);
            }
        }
    }

    private void EndDelay()
    {
        isDelaying = false;
    }

    public void LoadTestScene()
    {
        SceneManager.LoadScene("Test");
    }
    
    public void LoadSetupScene()
    {
        SceneManager.LoadScene("setup");
    }
}
