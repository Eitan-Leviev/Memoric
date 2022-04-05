using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Test : MonoBehaviour
{
    public float endTestTime;
    
    private int digNum;
    private int currIndex = 0;
    private int currNumPressed = 0;
    private int currCorrectNumber;
    
    private GameObject gameManager;
    
    // colors
    private GameObject regularColorObj;
    private Color regularColor;
    
    // flags
    private bool enablePressing = true;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");

        digNum = gameManager.GetComponent<GameManager>().DigitsGetter();
        
        // colors
        regularColorObj = GameObject.Find("regular");
        regularColor = regularColorObj.GetComponent<SpriteRenderer>().color;
    }

    public void SetCurrNumPressed(int newValue)
    {
        // set previous color back to the regular color
        GameObject.Find($"{currNumPressed}").GetComponent<Image>().color = regularColor;
        // update the current pressed number
        currNumPressed = newValue;
    }

    public bool IsRightNumberPressed()
    {
        currCorrectNumber = gameManager.GetComponent<GameManager>().ListRandomAccess(currIndex);
        currIndex++;
        if (currIndex == digNum) // if all numbers were guessed then disable pressing
        {
            enablePressing = false;
            
            // optional : back to setup scene after endTestTime seconds
            Invoke(nameof(LoadSetupScene), endTestTime);
        }
        
        // deal record
        if (currCorrectNumber == currNumPressed)
        {
            gameManager.GetComponent<GameManager>().AddScore();
        }
        
        return currCorrectNumber == currNumPressed;
    }

    public bool EnablePressingGetter()
    {
        return enablePressing;
    }
    
    public void LoadSetupScene()
    {
        SceneManager.LoadScene("setup");
    }
}
