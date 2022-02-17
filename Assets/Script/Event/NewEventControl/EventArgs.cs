using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArgs : MonoBehaviour
{
    /// <summary> 事件类型 </summary>
    public readonly string type;
    /// <summary> 事件参数 </summary>
    public readonly object[] args;

    public EventArgs(string type)
    {
        this.type = type;
    }

    public EventArgs(string type, params object[] args)
    {
        this.type = type;
        this.args = args;
    }

}
