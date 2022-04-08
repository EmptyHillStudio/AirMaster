using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortWithPlaneName_button : MonoBehaviour
{
    public DynamicScroll_ChosePlane choose;
    public void OnClick()
    {
        int result;
        List<Plane> planes = new List<Plane>();
        planes =ListOfDic();
        Debug.Log(planes.Count);
        for (int i=0;i<planes.Count-1;i++)
        {
            string name = planes[i].GetName();
            for(int j=i+1;j<planes.Count;j++)
            {
                result = string.Compare(name, planes[j].GetName(), true);
                if(result>0)//name´óÓÚplanes[i].GetName()
                {
                    Plane temp = planes[i];
                    planes[i] = planes[j];
                    planes[j] = temp;
                }
            }
        }
        choose.ShowAllPlane(planes);
    }
    public static List<Plane> ListOfDic()
    {
        List<Plane> planes = new List<Plane>();
        int length = 0;
        foreach (KeyValuePair<Plane, int> kvp in GlobalVariable.planeDic)
        {
            if (kvp.Value != 0)
            {
                planes.Add(kvp.Key);
            }
        }
        return planes;
    }
}
