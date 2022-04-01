using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UniLine : MonoBehaviour
{
    public TempVariable temp;
    public Dropdown caps;
    public void OnClose()
    {
        temp.tempLine = null;
        caps.options.Clear();
    }
}
