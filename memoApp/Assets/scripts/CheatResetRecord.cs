using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheatResetRecord : MonoBehaviour
{
    public int numOfClicks;
    
    public float timeLimitForClicks;

    private int clicksInARow = 0;

    private bool clicksStarted = false;
    
    [SerializeField] private UnityEvent displayRecord;
    

    public void Clicked()
    {
        clicksInARow++;
        
        if (! clicksStarted) // if first click
        {
            Invoke("ResetClicks", timeLimitForClicks);
            clicksStarted = true;
        }
        
        // check if user succeed the cheat
        if (clicksInARow == numOfClicks)
        {
            ResetRecord();
            displayRecord.Invoke();
            clicksInARow = 0; clicksStarted = false;
        }
    }

    private void ResetClicks()
    {
        clicksInARow = 0;
        clicksStarted = false;
    }
    
    // cant do that methode with unityEvent (differently from displayRecord event)
    // because the gameManager is not-destroyed-on-load
    // hence the gameManager reference in the inspector is corrupted after reloading scenes
    private void ResetRecord()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ResetRecord();
    }
}
