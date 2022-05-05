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
    public float endMoveTime; // how much time the moving-letter animation takes
    
    private GameObject playPauseToggleObj;

    public Sprite playSprite;
    public Sprite pauseSprite;

    private GameObject gameManager;

    public GameObject testButton;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        
        playPauseToggleObj = GameObject.Find("/Canvas/animParent/play - pause/Background");
        
        digNum = gameManager.GetComponent<GameManager>().DigitsGetter();
        Delay = gameManager.GetComponent<GameManager>().DelayGetter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<AudioSource>().Play();
        }
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
                Invoke("NumAnim", readingTime + Delay - endMoveTime);
                Invoke("EndDelay", readingTime + Delay);
            }
        }
        else
        {
            if (!isDelaying)
            {
                SceneManager.LoadScene("Test"); // without "test yourself" button. optional.
                return;
                
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

    private void NumAnim()
    {
        digitTxt.GetComponent<Animator>().SetTrigger("move num");
        GetComponent<AudioSource>().Play();
    }

    public void LoadTestScene()
    {
        if (currIndex == digNum)
        {
            SceneManager.LoadScene("Test");
        }
    }
    
    public void LoadSetupScene()
    {
        SceneManager.LoadScene("setup");
    }
    
    public void PlayPauseToggle()
    {
        // switch sprites
        playPauseToggleObj.GetComponent<Image>().sprite =
            Time.timeScale == 0 ? pauseSprite : playSprite;
        // play - pause
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
