using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResearchType
{
    SERVICE,
    TECHONOLOGY,
    INVESTMENT,
    MANAGEMENT
}

public class Research
{
    public ResearchType Type; //研究的类别
    public string UID; //每项研究的独立ID
    public int cost;//金钱花费
    public List<Research> Pre_researches;//前置研究
    bool Researched;

}

public class ResearchManager
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
