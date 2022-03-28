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
    //public EventHandleTest eventType = new EventHandleTest();
    public static List<string[]> Datas;
    EventTrigger trigger;
    static string ResourceData = Application.streamingAssetsPath + "/Data";
    string dataString;

    void Start()
    {
        //01      Jan     2019
        //CreateEvent.addTriggersListener(date, EventTriggerType.UpdateSelected, CreateEvent.myMehod);
        Datas = new List<string[]>();
        loadFile(ResourceData, "Events.csv");
        List<string> eventTypeList = EventHandleTest.GetEventTypeName();
        
        for (int i=0;i<Datas.Count;i++)
        {
            dataString = Datas[i][2];
            //if(Data[i][1].Equals("")&&
            if (Datas[i][1].Equals("")&& date.GetComponent<Text>().text==(Datas[i][2]))
            {
                EventUtil.DispatchEvent(eventTypeList[i]);
                
                //eventType.GetEventTypeName();
            }
            //Debug.Log(dataString);
            //Debug.Log(date.GetComponent<Text>().text);

        }
        if (date.GetComponent<Text>().text == "01		Jen		1970")
        {
            EventUtil.DispatchEvent(EventHandleTest.ON_CLICK);
        }
        
    }
    
    public void OnUpdateSelected()
    {
        Datas = new List<string[]>();
        loadFile(ResourceData, "Events.csv");
        List<string> eventTypeList = EventHandleTest.GetEventTypeName();
        for (int i = 0; i < Datas.Count; i++)
        {
            if (Datas[i][1].Equals("") && date.GetComponent<Text>().text == Datas[i][2])
            {
                EventUtil.DispatchEvent(eventTypeList[i]);
                Debug.Log(Datas[i][2]);
            }
            
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
    }*/
    

}
