using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    public float sceneEndAnimTime;

    private GameObject animParent;
    
    private void Awake()
    {
        // animParent = GameObject.Find("Canvas").transform.Find("anim parent").gameObject;
        var animParentTransform = GameObject.Find("Canvas").transform.Find("anim parent");
        if (animParentTransform)
        { animParent = animParentTransform.gameObject; }
    }

    public void LoadRandomizeScene()
    {
        var manager = GameObject.Find("GameManager");
        int digNum = manager.GetComponent<GameManager>().GetDigitsFromField();
        int delay = manager.GetComponent<GameManager>().GetDelayFromField();
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
            var animParentAnimator = animParent.GetComponent<Animator>();
            if (animParentAnimator)
            { animParentAnimator.SetTrigger("end scene"); }
            // load randomizing scene
            Invoke("LoadRandScene", sceneEndAnimTime);
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
