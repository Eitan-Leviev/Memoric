using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollControler : MonoBehaviour
{
    // control size
    private RectTransform rt;
    private Vector2 newSize;

    // control content
    private float xStart = -200;
    private float yStart = 100;
    private float xDelta = 200;
    private float yDelta = 300;
    private int rows = 30;
    private int cols = 4;
    private float rowHeight = 70;
    
    // the new obj
    public GameObject obj;

    public GameObject posTest;

    private void Awake()
    {
        // control size
        rt = GetComponent<RectTransform>();
        newSize = new Vector2(rt.sizeDelta.x, rowHeight * rows);
        rt.sizeDelta = newSize;
        
        // control content
        var counter = 0;
        var itemsNum = 7;
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Instantiate(obj,
                    new Vector3(xStart + xDelta * x,  yStart - yDelta * y, 0),
                    Quaternion.identity,
                    this.transform);

                counter++;

                if (counter == itemsNum) { return; }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
