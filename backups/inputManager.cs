using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputManager : MonoBehaviour
{
    private string digNum;
    private string delay;

    public GameObject digNumObj;

    private TouchScreenKeyboard keyboard;

    public void OpenKeyboard()
    {
        // keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
    
    public void GetDigitsNumber_Text()
    {
        // digNum = digNumObj.GetComponent<Text>().text;
        // print(digNum);
    }
}
