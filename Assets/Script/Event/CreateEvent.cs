using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreateEvent
{ 
    public delegate void MyMehod(BaseEventData pd);
    EventTrigger trigger;
    public void addTriggersListener(GameObject obj, EventTriggerType eventTriggerType, MyMehod myMehod)
    {
        EventTrigger ET = GetComponent<EventTrigger>();
        if (ET == null)
        {
            ET = obj.AddComponent<EventTrigger>();
        }
        if (trigger.triggers.Count == 0)
        {
            trigger.triggers = new List<EventTrigger.Entry>();
        }

        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(myMehod);
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventTriggerType;
        entry.callback.AddListener(callBack);

        trigger.triggers.Add(entry);
        Debug.Log("2");
    }

    public static void myMehod(BaseEventData pd)
    {
        Debug.Log(";-)");
    }

  
}

    

