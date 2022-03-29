using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResearchType
{
    SERVICE,
    TECHONOLOGY,
    INVESTMENT,
    MANAGEMENT,
    NULL
}

public class Research
{
    public ResearchType Type; //�о������
    public string Introduce; //����
    public string Name;
    public string UID; //ÿ���о��Ķ���ID
    public int Money_cost;//��Ǯ����
    public int Time_cost;//ʱ�仨��
    public string[] Pre_researches;//ǰ���о�
    public bool Researched; //�Ƿ����о�
    public Research(string UID, string name, string introduce, string moneycost, string type, string timecost, string pre)
    {
        this.UID = UID;
        this.Name = name;
        this.Introduce = introduce;
        this.Money_cost = Convert.ToInt32(moneycost);
        this.Time_cost = Convert.ToInt32(timecost);
        this.Type = GetType(type);
        this.Pre_researches = pre.Split(';');
        //Debug.Log("Research \"" + name + "\" is loaded! ");
    }
    public static ResearchType GetType(string type)
    {
        switch (type)
        {
            case "SERVICE":
                return ResearchType.SERVICE;
            case "TECHONOLOGY":
                return ResearchType.TECHONOLOGY;
            case "INVESTMENT":
                return ResearchType.INVESTMENT;
            case "MANAGEMENT":
                return ResearchType.MANAGEMENT;
            default:
                return ResearchType.NULL;
        }
    }
}

public class ResearchManager
{
    public Dictionary<string, Research> Researches;
    public ResearchManager()
    {
        this.Researches = new Dictionary<string, Research>();
    }

    public Research getResearchByUID(string UID)//����UID����R
    {
        Research r;
        Researches.TryGetValue(UID, out r);
        return r;
    }

    public void Add(Research research)
    {
        this.Researches.Add(research.UID, research);
    }
}
