using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class buttonTestEvent : MonoBehaviour
{
    
    public GameObject button;
    //CreateEvent create = new CreateEvent();
    // Start is called before the first frame update
    void Start()
    {
        
        CreateEvent.addTriggersListener(button, EventTriggerType.PointerEnter,CreateEvent.myMehod);
    }
    public static void myMed(BaseEventData pd)
    {
        Debug.Log("1.0");
    }
    // Update is called once per frame
    void Update()
    {
        
        //GameObject.Find("UI_Canvas").GetComponent<CreateEvent>().addTriggersListener(button, EventTriggerType.PointerClick, GameObject.Find("UI_Canvas").GetComponent<CreateEvent>().myMehod);
        //Debug.Log("1");
    }
}
