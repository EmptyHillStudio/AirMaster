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
    public ResearchType Type; //�о������
    public string UID; //ÿ���о��Ķ���ID
    public int cost;//��Ǯ����
    public List<Research> Pre_researches;//ǰ���о�
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
