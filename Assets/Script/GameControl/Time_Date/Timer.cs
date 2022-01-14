using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int nowtime;
    void Start()
    {
        GlobalVariable.gTimer = this;
        nowtime = 0;
    }

    void Update()
    {
        if (!GlobalVariable.IsPaused)
        {
            nowtime++;
        }
    }
    public int getNowTime()
    {
        return nowtime;
    }
}
