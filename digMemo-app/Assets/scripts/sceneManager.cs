using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void LoadRandomizeScene()
    {
        int digNum = GetComponent<GameManager>().GetDigitsNumber();
        int delay = GetComponent<GameManager>().GetDelay();
        // check if 2 values are supplied and valid
        if (digNum > 0 && delay >= 0)
        {
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
