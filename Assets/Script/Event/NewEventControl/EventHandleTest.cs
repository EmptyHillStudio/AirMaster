using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandleTest : MonoBehaviour
{
    // 定义事件名称
    public const string ON_CLICK = "Epidemic";
    

    private void Start()
    {
        // 添加监听器
        if (!EventUtil.HasListener(ON_CLICK)) 
            EventUtil.AddListener(ON_CLICK, OnClick);
        
        
    }

    // 处理点击事件
    public void OnClick(EventArgs evt)
    {
        Debug.Log("111111111");
    }

    
    // 移除监听器
    private void OnDestroy()
    {
        EventUtil.RemoveListener(ON_CLICK, OnClick);
        //EventUtil.RemoveListener(ON_CLICK2, OnClick2);
    }

}
