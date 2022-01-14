using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateControl : MonoBehaviour
{
    private Date now;
    private int pastTime;
    GameObject DateInfo;
    void Start()
    {
        now = GlobalVariable.GameDate;
        pastTime = GlobalVariable.gTimer.getNowTime();
        DateInfo = GameObject.Find("DateInfo");
        DateInfo.GetComponent<Text>().text = now.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int del = GlobalVariable.SpeedTime * GlobalVariable.SpeedTime;
        if (GlobalVariable.gTimer.getNowTime()- pastTime >= 35 / del)
        {
            pastTime = GlobalVariable.gTimer.getNowTime();
            now.dayPlus();
            DateInfo.GetComponent<Text>().text = now.ToString() ;
        }
    }
}
