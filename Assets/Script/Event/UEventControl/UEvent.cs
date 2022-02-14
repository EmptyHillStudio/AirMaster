using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UEvent : MonoBehaviour
{
    /// <summary>
    /// 事件类别
    /// </summary>
    public string eventType;

    /// <summary>
    /// 参数
    /// </summary>
    public object eventParams;

    /// <summary>
    /// 事件抛出者
    /// </summary>
    public object target;

    public UEvent(string eventType, object eventParams = null)
    {
        this.eventType = eventType;
        this.eventParams = eventParams;
    }
}
