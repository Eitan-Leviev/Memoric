using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPressed : MonoBehaviour
{
    private GameObject myCanvas;

    private int pressedNum;
    
    // colors
    private GameObject rightColorObj;
    private GameObject wrongColorObj;
    private Color rightColor;
    private Color wrongColor;

    private void Awake()
    {
        myCanvas = GameObject.Find("Canvas");

        rightColorObj = GameObject.Find("green");
        wrongColorObj = GameObject.Find("red");

        rightColor = rightColorObj.GetComponent<SpriteRenderer>().color;
        wrongColor = wrongColorObj.GetComponent<SpriteRenderer>().color;
    }

    public void GetThePressedNum()
    {
        if (myCanvas.GetComponent<Test>().EnablePressingGetter())
        {
            // convert to int
            pressedNum = int.Parse(gameObject.name);
            // update curr number
            myCanvas.GetComponent<Test>().SetCurrNumPressed(pressedNum);
            // check if user is right or wrong
            if (myCanvas.GetComponent<Test>().IsRightNumberPressed()) // if correct
            {
                // change color to right color
                GetComponent<Image>().color = rightColor;
            }
            else // if wrong
            {
                // change color to wrong color
                GetComponent<Image>().color = wrongColor;
            }
        }
    }
}
