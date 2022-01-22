using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class TimeControl : MonoBehaviour
{
    public Text TimesShowing;
    public Light_Dynamic Light;
    public GameObject StartButton;
    public GameObject PauseButton;
    public GameObject SpeedUpButton;
    public GameObject SlowDownButton;
    public GameObject PausingShowing;
    void Start()
    {
        if (GlobalVariable.IsPaused)
        {
            PauseButton.SetActive(false);
            PausingShowing.SetActive(true);
            StartButton.SetActive(true);
        }
        else
        {
            PauseButton.SetActive(true);
            PausingShowing.SetActive(false);
            StartButton.SetActive(false);
        }
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
            Light.speedtimes++;
            TimesShowing.text = GlobalVariable.SpeedTime.ToString() + "x";
        }
    }
    void SlowDown_Time()
    {
        if (GlobalVariable.SpeedTime > 1)
        {
            GlobalVariable.SpeedTime--;
            Light.speedtimes--;
            TimesShowing.text = GlobalVariable.SpeedTime.ToString() + "x";
        }
    }
}
