using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    
    [TriggerMode(TriggerMode.DATE, "day")]
    public void ResearchComplete()
    {
        List<string> uids = ResearchManager.Researching.Keys.ToList<string>();
        for (int i = 0; i < uids.Count; i++) 
        {
            Research r = ResearchManager.Researching[uids[i]];
            if (r.Time_cost - (GlobalVariable.GameDate - r.Starttime) <= 0) 
            {
                r.Status = ResearchStatus.FINISHED;
                GlobalVariable.DefaultManager.researchesManager.getResearchByUID(uids[i]).Status = ResearchStatus.FINISHED;
                Debug.Log("Research" + r.Name + " Complete!");
                ResearchManager.Researching.Remove(uids[i]);
            }
            else Debug.Log("�Ƽ� " + r.Name + " ʣ�� " + (r.Time_cost - (GlobalVariable.GameDate - r.Starttime)) + "��");
        }
    }
}
