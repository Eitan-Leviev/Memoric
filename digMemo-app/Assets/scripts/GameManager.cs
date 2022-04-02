using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

    private void Awake()
    {
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
        
        // enable Keyboard in mobile
        
        // GameObject go;
        // go.GetComponent<Button>().onClick.AddListener(gameManager.GetComponent<GameManager>().OpenKeyboard);
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
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void AddToRandomList(int numToAdd)
    {
        randomList.Add(numToAdd);
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

    public void ClearGame()
    {
        // Clear input
        randomList = new List<int>();
        digNum = 0;
        delay = -1;
        // reference all game objects
        var canvas = GameObject.Find("Canvas");
        startButton = canvas.transform.Find("startButton").gameObject;
        digitsField = canvas.transform.Find("InputDigNum").gameObject;
        delayField = canvas.transform.Find("InputDelay").gameObject;
        digitsText = digitsField.transform.Find("Text").gameObject.GetComponent<Text>();
        delayText = delayField.transform.Find("Text").gameObject.GetComponent<Text>();
    }
}
