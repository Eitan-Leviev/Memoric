using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayerPrefs : MonoBehaviour
{
    private InputField prefIF;

    private void Awake()
    {
        prefIF = GetComponent<InputField>();
        
        print(gameObject.name);
        
        if (gameObject.name == "InputDigNum")
        {
            PlayerPrefs.GetInt("prefNum", 1);
            prefIF.text = PlayerPrefs.GetInt("prefNum").ToString();
        }
        else
        {
            PlayerPrefs.GetInt("prefDelay", 0);
            prefIF.text = PlayerPrefs.GetInt("prefDelay").ToString();
        }
        
        print(PlayerPrefs.GetInt("prefNum"));
        print(PlayerPrefs.GetInt("prefDelay"));
    }


    public void SetPlayerPrefs(int playerPref)
    {
        if (gameObject.name == "InputDigNum")
        {
            PlayerPrefs.SetInt("prefNum", playerPref);
        }
        else
        {
            PlayerPrefs.SetInt("prefDelay", playerPref);
        }

        print("changed: " + PlayerPrefs.GetInt("prefNum"));
        print("changed: " + PlayerPrefs.GetInt("prefDelay"));
    }
}
