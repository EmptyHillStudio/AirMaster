using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventControl : MonoBehaviour
{
    public GameObject date;
    void Start()
    {
        if (date.GetComponent<Text>().text == "01		Jen		1970")
        {
            EventUtil.DispatchEvent(EventHandleTest.ON_CLICK);
        }
        
    }


}
