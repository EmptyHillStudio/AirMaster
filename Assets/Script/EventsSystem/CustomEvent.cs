using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trigger;

public class CustomEvent
{
    //�����������Զ���ȫ��static����

    [TriggerMode(TriggerMode.DATE, "day")]//������ʽ
    public void Debugs()//�����붯��
    {
        if (Random.Range(0f, 1f) < 0.5)
        {
            Debug.Log("����С��0.5�ĸ��ʴ����˸��¼�");
        }
    }
    [TriggerMode(TriggerMode.DATE, "month")]//������ʽ
    public void Debugs_Mon()//�����붯��
    {
        if (Random.Range(0f, 1f) < 0.5)
        {
            Debug.Log("����1�մ����˸��¼�");
        }
    }
    [TriggerMode(TriggerMode.DATE, "year")]//������ʽ
    public void Debugs_Year()//�����붯��
    {
        if (Random.Range(0f, 1f) < 0.5)
        {
            Debug.Log("����1��1�մ����˸��¼�");
        }
    }
    [TriggerMode(TriggerMode.DATE, "accurate", "2/2/1970" )]//������ʽ
    public void Debugs_Accurate()//�����붯��
    {
        Debug.Log("1970��2��2�մ����˸��¼� Debugs_Accurate");
    }
    
}
