using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUtil : MonoBehaviour
{
    /// <summary> �¼��ɷ��� </summary>
    private static EventDispatcher dispatcher = new EventDispatcher();

    /// <summary> ����¼������� </summary>
    /// <param name="eventType">�¼�����</param>
    /// <param name="eventHandler">�¼�������</param>
    public static void AddListener(string eventType, EventListener.EventHandler eventHandler)
    {
        dispatcher.AddListener(eventType, eventHandler);
    }

    /// <summary> �Ƴ��¼������� </summary>
    /// <param name="eventType">�¼�����</param>
    /// <param name="eventHandler">�¼�������</param>
    public static void RemoveListener(string eventType, EventListener.EventHandler eventHandler)
    {
        dispatcher.RemoveListener(eventType, eventHandler);
    }

    /// <summary> �Ƿ��Ѿ�ӵ�и����͵��¼� </summary>
    /// <param name="eventType">�¼�����</param>
    public static bool HasListener(string eventType)
    {
        return dispatcher.HasListener(eventType);
    }

    /// <summary> �ɷ��¼� </summary>
    /// <param name="eventType">�¼�����</param>
    public static void DispatchEvent(string eventType, params object[] args)
    {
        dispatcher.DispatchEvent(eventType, args);
    }

    /// <summary> ���������¼������� </summary>
    public static void Clear()
    {
        dispatcher.Clear();
    }

}


