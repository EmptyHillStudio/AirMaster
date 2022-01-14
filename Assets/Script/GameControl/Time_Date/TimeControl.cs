using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class TimeControl : MonoBehaviour
{
    GameObject TimesShowing;
    GameObject StartButton;
    GameObject PauseButton;
    GameObject SpeedUpButton;
    GameObject SlowDownButton;
    GameObject PausingShowing;
    void Start()
    {
        TimesShowing = GameObject.Find("SpeedInfo");
        StartButton = GameObject.Find("StartButton");
        PauseButton = GameObject.Find("PauseButton");
        PauseButton.SetActive(false);
        SpeedUpButton = GameObject.Find("SpeedUp");
        PausingShowing = GameObject.Find("PausingShowing");
        SlowDownButton = GameObject.Find("SlowDown");
        StartButton.GetComponent<Button>().onClick.AddListener(Start_Time);
        PauseButton.GetComponent<Button>().onClick.AddListener(Pause_Time);
        SpeedUpButton.GetComponent<Button>().onClick.AddListener(SpeedUp_Time);
        SlowDownButton.GetComponent<Button>().onClick.AddListener(SlowDown_Time);
    }

    void Start_Time()
    {
        GlobalVariable.IsPaused = false;
        StartButton.SetActive(false);
        PauseButton.SetActive(true);
        PausingShowing.SetActive(false);
    }
    void Pause_Time()
    {
        GlobalVariable.IsPaused = true;
        StartButton.SetActive(true);
        PauseButton.SetActive(false);
        PausingShowing.SetActive(true);
    }
    void SpeedUp_Time()
    {
        if (GlobalVariable.SpeedTime <5)
        {
            GlobalVariable.SpeedTime++;
            TimesShowing.GetComponent<Text>().text = GlobalVariable.SpeedTime.ToString() + "x";
        }
    }
    void SlowDown_Time()
    {
        if (GlobalVariable.SpeedTime > 1)
        {
            GlobalVariable.SpeedTime--;
            TimesShowing.GetComponent<Text>().text = GlobalVariable.SpeedTime.ToString() + "x";
        }
    }
}
