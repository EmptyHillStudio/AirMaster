using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class EventControl : MonoBehaviour
{
    /*public GameObject date;
    public EventHandleTest eventType = new EventHandleTest();
    public static List<string[]> Datas;
    EventTrigger trigger;
   
    void Start()
    {
        
        CreateEvent.addTriggersListener(date, EventTriggerType.UpdateSelected, CreateEvent.myMehod);
        Datas = new List<string[]>();
        loadFile(Application.dataPath+"/Res/Data","Events.csv");
        List<string> eventTypeList = eventType.GetEventTypeName();
        for (int i=0;i<Datas.Count;i++)
        {
            if(Datas[i][1].Equals("")&& date.GetComponent<Text>().text==Datas[i][2])
            {
                EventUtil.DispatchEvent(eventTypeList[i]);
                //eventType.GetEventTypeName();
            }
        }
        if (date.GetComponent<Text>().text == "01		Jen		1970")
        {
            EventUtil.DispatchEvent(EventHandleTest.ON_CLICK);
        }
        
    }
    private void PEnter(BaseEventData pd)
    {
        Debug.Log("Penter");
    }
    public void OnUpdateSelected()
    {
        /*Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Events.csv");
        foreach (var line in Datas)
        {
            if(line[1].Equals("")&& date.GetComponent<Text>().text==line[2])
            {

            }
        }
        
        Debug.Log("date¸Ä±ä");
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
    */

}
