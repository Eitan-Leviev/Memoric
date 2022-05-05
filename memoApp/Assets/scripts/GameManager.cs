using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float sceneStartAnimTime;
    
    private GameObject startButton;
    
    // input vars
    private int digNum;
    private int delay;

    // input fields
    private GameObject digitsField;
    private GameObject delayField;
    
    // input text
    private Text digitsText;
    private Text delayText;

    // mobile keyboard
    private TouchScreenKeyboard keyboard;
    
    // randomize
    private List<int> randomList;
    private List<int> answersList;

    // records
    private int score = 0;
    public static bool BeatRecordIndicator = false; // indicates if player had bitten the best record in current game
    public static bool Sound = true; // indicates if sound is on/off
    private int theRecord; // for debug

    private void Awake()
    {
        // Time.timeScale = 0.5f;
        
        // do not destroy GameManager
        
        var gameManagers = GameObject.FindGameObjectsWithTag("GameManager");

        if (gameManagers.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        // reference gameObjects

        ClearGame();

        // enable to input integers only
        
        digitsField.GetComponent<InputField>().characterValidation = InputField.CharacterValidation.Integer;
        delayField.GetComponent<InputField>().characterValidation = InputField.CharacterValidation.Integer;
        
        // reference button event
        
        startButton.GetComponent<Button>().onClick.AddListener(GetComponent<sceneManager>().LoadRandomizeScene);
        
        // control Keyboard in mobile

        // GameObject go;
        // digitsField.GetComponent<Button>().onClick.AddListener(gameManager.GetComponent<GameManager>().OpenKeyboard);
        // digitsField.GetComponent<EventTrigger>().OnPointerClick(new PointerEventData(eventSystem: EventSystem.current));
        
        theRecord = PlayerPrefs.GetInt("BestRecord", 0);
    }

    private void Start()
    {
        var canvas = GameObject.Find("Canvas");
        var animParent = canvas.transform.Find("anim parent").gameObject;
        animParent.GetComponent<Animator>().SetTrigger("start");
        Invoke("ScoreAnim", sceneStartAnimTime);
    }

    // return 0 if value was not supplied
    public int GetDigitsFromField()
    {
        if (digitsText.text != "")
        {
            digNum = int.Parse(digitsText.text);
        }
        
        return digNum;
    }

    public int DigitsGetter()
    { return digNum; }
    
    // return -1 if value was not supplied
    public int GetDelayFromField()
    {
        if (delayText.text != "")
        {
            delay = int.Parse(delayText.text);
        }
        
        return delay;
    }
    
    public int DelayGetter()
    { return delay; }

    public void OpenKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.PhonePad);
    }

    public void AddToRandomList(int numToAdd)
    {
        randomList.Add(numToAdd);
    }
    
    public void AddToAnswersList(int numToAdd)
    {
        answersList.Add(numToAdd);
    }

    // return -1 if index out of range
    public int ListRandomAccess(int index)
    {
        if (index >= 0 && index <= digNum)
        {
            return randomList[index];
        }

        return -1;
    }
    
    // return -1 if index out of range
    public int AnswersListRandomAccess(int index)
    {
        if (index >= 0 && index <= digNum)
        {
            return answersList[index];
        }

        return -1;
    }

    public void AddScore()
    {
        score++;
        
        // if player had bitten the best record
        if (score > PlayerPrefs.GetInt("BestRecord", 0))
        {
            PlayerPrefs.SetInt("BestRecord", score); // update best record
            PlayerPrefs.SetInt("BestDelay", delay); // update best record delay
            BeatRecordIndicator = true; // indicate that record had been bitten
        }
    }

    public void DelayRecord()
    {
        // check if correct numbers is the record.
        // if so - set the delay-record accordingly
        if (score == PlayerPrefs.GetInt("BestRecord", 0))
        {
            if (delay < PlayerPrefs.GetInt("BestDelay", int.MaxValue))
            {
                PlayerPrefs.SetInt("BestDelay", delay);
            }
        }
    }

    public (int, int) RecordGetter()
    {
        return (PlayerPrefs.GetInt("BestRecord", 0), 
            PlayerPrefs.GetInt("BestDelay", int.MaxValue));
    }

    public void ClearGame()
    {
        // Clear fields
        randomList = new List<int>();
        answersList = new List<int>();
        digNum = 1;
        delay = 0;
        score = 0;
        // reference all game objects
        var canvas = GameObject.Find("Canvas");
        var animParent = canvas.transform.Find("anim parent").gameObject;
        startButton = animParent.transform.Find("startButton").gameObject;
        digitsField = animParent.transform.Find("InputDigNum").gameObject;
        delayField = animParent.transform.Find("InputDelay").gameObject;
        digitsText = digitsField.transform.Find("numTxt").gameObject.GetComponent<Text>();
        delayText = delayField.transform.Find("delayTxt").gameObject.GetComponent<Text>();
    }

    private void ScoreAnim()
    {
        var canvas = GameObject.Find("Canvas");
        var animParent = canvas.transform.Find("anim parent").gameObject;
        var scoreObj = animParent.transform.Find("best record num").gameObject;
        scoreObj.GetComponent<Animator>().SetTrigger("recordBreak");
    }

    public void ResetRecord()
    {
        // set to default
        PlayerPrefs.SetInt("BestRecord", 0);
        PlayerPrefs.SetInt("BestDelay", int.MaxValue);
    }
}
