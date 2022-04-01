using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TempVariable : MonoBehaviour
{
    public CityBindToBoard InfomationBoard;
    public GameObject LineCreate;//�����
    public Text City_begin, City_end;//��ʼ���е����ֶ���
    public Image BeginScale, EndScale;//��ʼ���еĳ���ͼ��
    public Text distance, distance_real;
    public Line tempLine;
    public City TempCity;

    public Dropdown captains;
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
                //���������յ���
                City bCity = tempLine.GetPoints()[0], eCity = tempLine.GetPoints()[1];
                City_begin.text = bCity.name;
                City_end.text = eCity.name;
                //���������յ��ͼ��
                BeginScale.sprite = bCity.ScaleImage;
                //Debug.Log(bCity.ScaleImage.name);
                EndScale.sprite = eCity.ScaleImage;
                //���þ������ʵ����
                distance.text = "���룺" + tempLine.distance.ToString() + " km";
                distance_real.text = "��ʵ���룺" + tempLine.real_distance.ToString() + " km";
                //���ӻ���ѡ��
                Dictionary<int, PlaneCaptain> caps = GlobalVariable.DefaultManager.planeCaptainsManager.captains;
                List<Dropdown.OptionData> capOptions = new List<Dropdown.OptionData>();
                foreach(KeyValuePair<int, PlaneCaptain> pc in caps)
                {
                    if(pc.Value.state == CaptainState.FREE)
                    {
                        int an = pc.Key + 1;
                        capOptions.Add(new Dropdown.OptionData(pc.Value.name));
                        //Debug.Log(pc.Key + "\t" + pc.Value.name);
                    }
                }
                //��ȡ����

                //���ý��水ť״̬�������صĿƼ��Ƿ������

                //���ð�ť��״̬Ϊȫ�ֱ�����ѡ��״̬

                //����Ԥ�������

                //������һ����ť�Ŀ�����

                captains.AddOptions(capOptions);
                

                LineCreate.SetActive(true);
                
                GlobalVariable.ChooseCity = GlobalChooseCityState.NORMAL;
                break;
        }
    }
}
