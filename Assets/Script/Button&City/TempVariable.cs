using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TempVariable : MonoBehaviour
{
    public CityBindToBoard InfomationBoard;
    public GameObject LineCreate;//�����
    public GameObject City_begin;
    public GameObject City_end;
    public Text Distance;
    public Text Distance_Real;
    public Line tempLine;
    public City TempCity;
    public TempVariable()
    {
        this.tempLine = new Line(0);
        this.TempCity = null;
    }
    public void Oper(City c)
    {
        ///<summary>
        /// �÷������ڸı������е�״̬��ͬʱ������c���ݳ�Ϊ��ʱ���������ڴ���һ������Ϣ��
        ///</summary>>
        TempCity = c;
        switch (GlobalVariable.ChooseCity)
        {
            case GlobalChooseCityState.NORMAL:
                InfomationBoard.UpdateContent(TempCity);
                break;
            case GlobalChooseCityState.CREATELINE:
                tempLine.SetPoints(1, TempCity);
                //Debug.Log("ѡ��ɹ���ѡ������Ϊ��" + tempLine.GetPoints()[0].name + "���յ�Ϊ��" + tempLine.GetPoints()[1].name + "�����ؾ���Ϊ��" + tempLine.GetDistance());
                
                LineCreate.SetActive(true);
                GlobalVariable.ChooseCity = GlobalChooseCityState.NORMAL;
                break;
        }
    }
}
