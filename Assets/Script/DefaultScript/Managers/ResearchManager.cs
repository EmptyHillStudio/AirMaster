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
    public ResearchType Type; //研究的类别
    public string Introduce; //介绍
    public string Name;
    public string UID; //每项研究的独立ID
    public int Money_cost;//金钱花费
    public int Time_cost;//时间花费
    public string[] Pre_researches;//前置研究
    public bool Researched; //是否已研究
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

    public Research getResearchByUID(string UID)//根据UID查找R
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
