using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UEventDispatcher : MonoBehaviour
{
    protected Dictionary<string, UEventListener> eventListenerDict;

    public UEventDispatcher()
    {
        this.eventListenerDict = new Dictionary<string, UEventListener>();
    }

    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="eventType">�¼����</param>
    /// <param name="callback">�ص�����</param>
    public void addEventListener(string eventType, UEventListener.EventListenerDelegate callback)
    {
        if (!this.eventListenerDict.ContainsKey(eventType))
        {
            this.eventListenerDict.Add(eventType, new UEventListener());
        }
        this.eventListenerDict[eventType].OnEvent += callback;
    }

    /// <summary>
    /// �Ƴ��¼�
    /// </summary>
    /// <param name="eventType">�¼����</param>
    /// <param name="callback">�ص�����</param>
    public void removeEventListener(string eventType, UEventListener.EventListenerDelegate callback)
    {
        if (this.eventListenerDict.ContainsKey(eventType))
        {
            this.eventListenerDict[eventType].OnEvent -= callback;
        }
    }

    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="evt">Evt.</param>
    /// <param name="gameObject">Game object.</param>
    public void dispatchEvent(UEvent evt, object gameObject)
    {
        UEventListener eventListener = eventListenerDict[evt.eventType];
        if (eventListener == null) return;

        evt.target = gameObject;
        eventListener.Excute(evt);
    }

    /// <summary>
    /// �Ƿ�����¼�
    /// </summary>
    /// <returns><c>true</c>, if listener was hased, <c>false</c> otherwise.</returns>
    /// <param name="eventType">Event type.</param>
    public bool hasListener(string eventType)
    {
        return this.eventListenerDict.ContainsKey(eventType);
    }
}
