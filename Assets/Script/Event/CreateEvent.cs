using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreateEvent
{ 
    public delegate void MyMehod(BaseEventData pd);
    
    public static void addTriggersListener(GameObject obj, EventTriggerType eventTriggerType, MyMehod myMehod)
    {
        EventTrigger ET = obj.GetComponent<EventTrigger>();
        if (ET == null)
        {
            ET = obj.AddComponent<EventTrigger>();
        }
        if (ET.triggers.Count == 0)
        {
            ET.triggers = new List<EventTrigger.Entry>();
        }

        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(myMehod);
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventTriggerType;
        entry.callback.AddListener(callBack);

        ET.triggers.Add(entry);
        Debug.Log("2");
    }

    public static void myMehod(BaseEventData pd)
    {
        Debug.Log(";-)");
    }

  
}

    

