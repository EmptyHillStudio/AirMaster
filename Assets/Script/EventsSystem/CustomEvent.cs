using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trigger;

public class CustomEvent
{
    //可以在这里自定义全局static变量

    [TriggerMode(TriggerMode.DATE, "day")]//触发方式
    public void Debugs()//条件与动作
    {
        if (Random.Range(0f, 1f) < 0.5)
        {
            Debug.Log("当天小于0.5的概率触发了该事件");
        }
    }
    [TriggerMode(TriggerMode.DATE, "month")]//触发方式
    public void Debugs_Mon()//条件与动作
    {
        if (Random.Range(0f, 1f) < 0.5)
        {
            Debug.Log("该月1日触发了该事件");
        }
    }
    [TriggerMode(TriggerMode.DATE, "year")]//触发方式
    public void Debugs_Year()//条件与动作
    {
        if (Random.Range(0f, 1f) < 0.5)
        {
            Debug.Log("该年1月1日触发了该事件");
        }
    }
    [TriggerMode(TriggerMode.DATE, "accurate", "2/2/1970" )]//触发方式
    public void Debugs_Accurate()//条件与动作
    {
        Debug.Log("1970年2月2日触发了该事件 Debugs_Accurate");
    }
    
}
