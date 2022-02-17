using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandleTest : MonoBehaviour
{
    // �����¼�����
    public const string ON_CLICK = "Epidemic";
    

    private void Start()
    {
        // ��Ӽ�����
        if (!EventUtil.HasListener(ON_CLICK)) 
            EventUtil.AddListener(ON_CLICK, OnClick);
        
        
    }

    // �������¼�
    public void OnClick(EventArgs evt)
    {
        Debug.Log("111111111");
    }

    
    // �Ƴ�������
    private void OnDestroy()
    {
        EventUtil.RemoveListener(ON_CLICK, OnClick);
        //EventUtil.RemoveListener(ON_CLICK2, OnClick2);
    }

}
