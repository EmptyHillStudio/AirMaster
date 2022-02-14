using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UEvent : MonoBehaviour
{
    /// <summary>
    /// �¼����
    /// </summary>
    public string eventType;

    /// <summary>
    /// ����
    /// </summary>
    public object eventParams;

    /// <summary>
    /// �¼��׳���
    /// </summary>
    public object target;

    public UEvent(string eventType, object eventParams = null)
    {
        this.eventType = eventType;
        this.eventParams = eventParams;
    }
}
