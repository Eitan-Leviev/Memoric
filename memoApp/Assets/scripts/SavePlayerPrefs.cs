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
    }
}
