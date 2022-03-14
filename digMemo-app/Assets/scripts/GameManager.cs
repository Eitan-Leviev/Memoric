using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject[] gameManagers;

    public GameObject startButton;
    
    // get input
    private int digNum = 0;
    private int delay;
    
    public GameObject digNumObj;
    public GameObject delayObj;

    // control input
    public GameObject inputDigits;
    public GameObject inputDelay;

    // mobile keyboard
    private TouchScreenKeyboard keyboard;
    
    // randomize
    private List<int> randomList = new List<int>();

    private void Awake()
    {
        gameManagers = GameObject.FindGameObjectsWithTag("GameManager");

        if (gameManagers.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        // enable to input integers only
        inputDigits.GetComponent<InputField>().characterValidation = InputField.CharacterValidation.Integer;
        inputDelay.GetComponent<InputField>().characterValidation = InputField.CharacterValidation.Integer;
        
        // reference button event
        startButton.GetComponent<Button>().onClick.AddListener(GetComponent<sceneManager>().LoadRandomizeScene);
        // GameObject go;
        // go.GetComponent<Button>().onClick.AddListener(gameManager.GetComponent<GameManager>().OpenKeyboard);
    }

    // return -1 if value was not supplied
    public int GetDigitsNumber()
    {
        if (digNumObj.GetComponent<Text>().text != "")
        {
            digNum = int.Parse(digNumObj.GetComponent<Text>().text);
            return digNum;
        }
        
        return -1;
    }

    public int DigNumGetter()
    {
        return digNum;
    }
    
    // return -1 if value was not supplied
    public int GetDelay()
    {
        if (delayObj.GetComponent<Text>().text != "")
        {
            delay = int.Parse(delayObj.GetComponent<Text>().text);
            return delay;
        }

        return -1;
    }
    
    public int DelayGetter()
    {
        return delay;
    }

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
}
