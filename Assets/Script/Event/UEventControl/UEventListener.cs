using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UEventListener : MonoBehaviour
{
    public UEventListener() { }

    public delegate void EventListenerDelegate(UEvent evt);
    public event EventListenerDelegate OnEvent;

    public void Excute(UEvent evt)
    {
        if (OnEvent != null)
        {
            this.OnEvent(evt);
        }
    }
}
