using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceGameObjects : MonoBehaviour
{
    private void Awake()
    { 
        var gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManager>().ClearGame();
    }
}
