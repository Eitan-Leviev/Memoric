using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumInit : MonoBehaviour
{
    // 'correct' is the correct number in the current given index
    // 'input' is the number that the user guessed in the Test scene, in the current given index
    
    
    private Color rightColor;
    private Color wrongColor;
    private GameObject manager;
    private Text correctTxt;
    private Text inputTxt;

    private void Awake()
    {
        rightColor = GameObject.Find("green").GetComponent<SpriteRenderer>().color;
        wrongColor = GameObject.Find("red").GetComponent<SpriteRenderer>().color;
        manager = GameObject.Find("GameManager");
        correctTxt = transform.Find("correct").GetComponent<Text>();
        inputTxt = transform.Find("answer").GetComponent<Text>();
    }

    public void Init(int currInd)
    {
        var managerScript = manager.GetComponent<GameManager>();
        var correct = managerScript.ListRandomAccess(currInd);
        var input = managerScript.AnswersListRandomAccess(currInd);
        
        // set color
            if (correct == input)
            { GetComponent<Image>().color = rightColor; }
            else { GetComponent<Image>().color = wrongColor; }

            // set input num
        inputTxt.text = input.ToString();
        
        // set correct num
            // if user were wrong - show the correct answer
            if (correct != input)
            { correctTxt.text = correct.ToString(); }
    }
}
