using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedBack : MonoBehaviour
{
    // control size
    private RectTransform rt;
    private Vector2 newSize;

    // control content
    private float xStart = -200;
    private float yStart = 100;
    // private float xStart = -400;
    // private float yStart = -300;
    private float xDelta = 200;
    private float yDelta = 300;
    private int rows;
    private int cols = 4;
    private float rowHeight = 70;
    
    // number obj
    public GameObject numObj;
    
    private void Awake()
    {
# if UNITY_ANDROID
        xStart = -400;
        yStart = -300;
# endif
        var itemsNum = GameObject.Find("GameManager").GetComponent<GameManager>().DigitsGetter();
        rows = (int) Math.Ceiling(itemsNum / (float) cols);
        
        // control size
        rt = GetComponent<RectTransform>();
        newSize = new Vector2(rt.sizeDelta.x, rowHeight * rows);
        rt.sizeDelta = newSize;

        // control content
        var counter = 0;
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                // Instantiate new number
                var newNum = Instantiate(numObj,
                    new Vector3(xStart + xDelta * x,  yStart - yDelta * y, 0),
                    Quaternion.identity,
                    this.transform);
                // initialize the new obj
                newNum.GetComponent<NumInit>().Init(counter);

                counter++;

                if (counter == itemsNum) { return; }
            }
        }
    }

    public void LoadSetupScene()
    {
        SceneManager.LoadScene("setup");
    }
}
