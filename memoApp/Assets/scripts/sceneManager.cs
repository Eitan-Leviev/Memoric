using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    public float animTime;

    private GameObject animParent;

    private void Awake()
    {
        animParent = GameObject.Find("Canvas").transform.Find("anim parent").gameObject;
    }

    public void LoadRandomizeScene()
    {
        int digNum = GetComponent<GameManager>().GetDigitsFromField();
        int delay = GetComponent<GameManager>().GetDelayFromField();
        // check if 2 values are supplied and valid
        if (digNum > 0 && delay >= 0)
        {
            // update player prefs
            animParent = GameObject.Find("Canvas").transform.Find("anim parent").gameObject;
            var digitsInputField = animParent.transform.Find("InputDigNum").gameObject;
            var delayInputField = animParent.transform.Find("InputDelay").gameObject;
            digitsInputField.GetComponent<SavePlayerPrefs>().SetPlayerPrefs(digNum);
            delayInputField.GetComponent<SavePlayerPrefs>().SetPlayerPrefs(delay);

            // play end scene anim
            animParent.GetComponent<Animator>().SetTrigger("end scene");
            // load randomizing scene
            Invoke("LoadRandScene", animTime);
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
    
    public void LoadRandScene()
    {
        SceneManager.LoadScene("randomize");
    }
}
