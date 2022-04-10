using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener
{
    /// <summary> �¼�������ί�� </summary>
    public delegate void EventHandler(EventArgs eventArgs);
    /// <summary> �¼����������� </summary>
    public EventHandler eventHandler;

    /// <summary> ����������ӵ��¼� </summary>
    public void Invoke(EventArgs eventArgs)
    {
        if (eventHandler != null) eventHandler.Invoke(eventArgs);
    }

    /// <summary> ���������¼�ί�� </summary>
    public void Clear()
    {
        eventHandler = null;
    }

}


