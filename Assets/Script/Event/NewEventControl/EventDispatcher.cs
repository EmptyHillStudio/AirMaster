using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher
{
    //// <summary> �¼�Map </summary>
    private Dictionary<string, EventListener> dic = new Dictionary<string, EventListener>();

    /// <summary> ����¼������� </summary>
    /// <param name="eventType">�¼�����</param>
    /// <param name="eventHandler">�¼�������</param>
    public void AddListener(string eventType, EventListener.EventHandler eventHandler)
    {
        EventListener invoker;
        if (!dic.TryGetValue(eventType, out invoker))
        {
            invoker = new EventListener();
            dic.Add(eventType, invoker);
        }
        invoker.eventHandler += eventHandler;
        
    }

    /// <summary> �Ƴ��¼������� </summary>
    /// <param name="eventType">�¼�����</param>
    /// <param name="eventHandler">�¼�������</param>
    public void RemoveListener(string eventType, EventListener.EventHandler eventHandler)
    {
        EventListener invoker;
        if (dic.TryGetValue(eventType, out invoker)) invoker.eventHandler -= eventHandler;
    }

    /// <summary> �Ƿ��Ѿ�ӵ�и����͵��¼� </summary>
    /// <param name="eventType">�¼�����</param>
    public bool HasListener(string eventType)
    {
        return dic.ContainsKey(eventType);
    }

    /// <summary> �ɷ��¼� </summary>
    /// <param name="eventType">�¼�����</param>
    public void DispatchEvent(string eventType, params object[] args)
    {
        EventListener invoker;
        if (dic.TryGetValue(eventType, out invoker))
        {
            EventArgs evt;
            if (args == null || args.Length == 0)
            {
                evt = new EventArgs(eventType);
            }
            else
            {
                evt = new EventArgs(eventType, args);
            }
            invoker.Invoke(evt);
        }
    }

    /// <summary> ���������¼������� </summary>
    public void Clear()
    {
        foreach (EventListener value in dic.Values)
        {
            value.Clear();
        }
        dic.Clear();
    }

}


