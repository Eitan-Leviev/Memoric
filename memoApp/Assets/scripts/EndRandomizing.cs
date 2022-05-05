using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRandomizing : MonoBehaviour
{
    public void Ending()
    {
        var gameObj = GameObject.Find("Canvas");
        gameObj.GetComponent<Randomize>().LoadTestScene();
    }
}
