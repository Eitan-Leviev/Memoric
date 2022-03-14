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


    // // right color abgr
    // private float rightColor_R;
    // private float rightColor_G;
    // private float rightColor_B;
    // // wrong color
    // private float wrongColor_R;
    // private float wrongColor_G;
    // private float wrongColor_B;

    private void Awake()
    {
        // print("im awake!");
        
        myCanvas = GameObject.Find("Canvas");

        rightColorObj = GameObject.Find("green");
        wrongColorObj = GameObject.Find("red");
        
        // // colors
        // rightColor_R = rightColorObj.GetComponent<SpriteRenderer>().color.r;
        // rightColor_G = rightColorObj.GetComponent<SpriteRenderer>().color.g;
        // rightColor_B = rightColorObj.GetComponent<SpriteRenderer>().color.b;
        //
        // wrongColor_R = wrongColorObj.GetComponent<SpriteRenderer>().color.r;
        // wrongColor_G = wrongColorObj.GetComponent<SpriteRenderer>().color.g;
        // wrongColor_B = wrongColorObj.GetComponent<SpriteRenderer>().color.b;
        //
        // rightColor = new Color(rightColor_R, rightColor_G, rightColor_B, 1);
        // wrongColor = new Color(wrongColor_R, wrongColor_G, wrongColor_B, 1);

        rightColor = rightColorObj.GetComponent<SpriteRenderer>().color;
        wrongColor = wrongColorObj.GetComponent<SpriteRenderer>().color;
    }

    public void GetThePressedNum()
    {
        // print("is pressed!");
        
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
