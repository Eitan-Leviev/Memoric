using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    private AudioListener al;

    private void Awake()
    {
        GetComponent<Image>().sprite = GameManager.Sound ? sprite1 : sprite2;
        al = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        al.enabled = GameManager.Sound;
    }

    public void OnClick()
    {
        print("ב");
        // swap sprites
        GetComponent<Image>().sprite =  GameManager.Sound ? sprite2 : sprite1;
        al.enabled = ! al.enabled;
        GameManager.Sound = !GameManager.Sound;
    }
}
