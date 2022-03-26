using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class DateControl : MonoBehaviour
{
    private Date now;
    private int pastTime;
    public GameObject DateInfo;
    public static List<string[]> Datas;
    public int eventline;
    public List<string> eventTypeList;
    //public EventHandleTest eventType = new EventHandleTest();
    void Start()
    {
        now = GlobalVariable.GameDate;
        pastTime = GlobalVariable.gTimer.getNowTime();
        /*//DateInfo = GameObject.Find("DateInfo");
        DateInfo.GetComponent<Text>().text = now.ToString();
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Events.csv");
        eventTypeList = EventHandleTest.GetEventTypeName();
        for (int i = 1; i < Datas.Count; i++)
        {

            if (Datas[i][1].Equals("") && now.ToString()== Datas[i][2])
            {
                EventUtil.DispatchEvent(eventTypeList[i]);
                eventline = i;
                //eventType.GetEventTypeName();
                
            }
            else
            {
                break;
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        int del = GlobalVariable.SpeedTime * GlobalVariable.SpeedTime;
        if (GlobalVariable.gTimer.getNowTime()- pastTime >= 35 / del)
        {
            pastTime = GlobalVariable.gTimer.getNowTime();
            now.dayPlus();
            /*DateInfo.GetComponent<Text>().text = now.ToString() ;
            for (int i = eventline+1 ; i < Datas.Count; i++)
            {
                if (Datas[i][1].Equals("") && now.ToString() == Datas[i][2])
                {
                    EventUtil.DispatchEvent(eventTypeList[i]);
                    //eventType.GetEventTypeName();
                }
            }*/
        }
    }
    public static void loadFile(string path, string fileName)
    {
        Datas.Clear();
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "/" + fileName);
            Debug.Log("file " + path + "/" + fileName + " is finded!");
        }
        catch
        {
            Debug.Log("file don't exist!");
        }
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            Datas.Add(line.Split(','));
        }
        sr.Close();
        sr.Dispose();
    }
}
