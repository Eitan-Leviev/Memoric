using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    public void LoadRandomizeScene()
    {
        int digNum = GetComponent<GameManager>().GetDigitsFromField();
        int delay = GetComponent<GameManager>().GetDelayFromField();
        // check if 2 values are supplied and valid
        if (digNum > 0 && delay >= 0)
        {
            // update player prefs
            var digitsInputField = GameObject.Find("Canvas").transform.Find("InputDigNum").gameObject;
            var delayInputField = GameObject.Find("Canvas").transform.Find("InputDelay").gameObject;
            digitsInputField.GetComponent<SavePlayerPrefs>().SetPlayerPrefs(digNum);
            delayInputField.GetComponent<SavePlayerPrefs>().SetPlayerPrefs(delay);
            
            // load randomizing scene
            SceneManager.LoadScene("randomize");
        }
    }

    public void LoadTestScene()
    {
        SceneManager.LoadScene("Test");
    }
    
    public void LoadSetupScene()
    {
        SceneManager.LoadScene("setup");
    }
}
