using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicScroll_ChosePlane : MonoBehaviour
{
    private static PlanesManager planemanager;
    public  GameObject Item;
    public  GameObject Noneimage;
    public  GameObject parent;
    Vector2 contentSize;
    float itemHeight;
    Vector3 itemLocalPos;
    List<GameObject> itemList = new List<GameObject>();
    void Start()
    {
        //GlobalVariable gv = new GlobalVariable();
        int IsHas = 0;//没有可使用的飞机
        parent = GameObject.Find("Content");
        contentSize = parent.GetComponent<RectTransform>().sizeDelta;
        itemHeight = Item.GetComponent<RectTransform>().rect.height;
        itemLocalPos = Item.transform.localPosition;
        List<Plane> planes = new List<Plane>();
        planes =ListOfDic();
        ShowAllPlane(planes);
        
        
        
        /*
        if (GlobalVariable.planeDic == null)
        {
            Debug.Log("null");
            Noneimage.SetActive(true);
            ChoseImage.SetActive(false);
        }
        else
        {
            int _count = PlanesManager.LengthOfDic();
            List<Plane> list = new List<Plane>(GlobalVariable.planeDic.Keys);
            Debug.Log(_count);
            //����֮ǰ�����ɵ�item������б�
            itemList.Clear();

            //�� Content ������ _count ��item
            if (_count > 0)
            {
                Item.SetActive(true);   //��һ��itemʵ���Ѿ������б���һ��λ�ã�ֱ�Ӽ���
                itemList.Add(Item);
                int i = 1;

                while (i < _count)
                {
                    int IsUse = 0;//�÷ɻ�ȫ��δ��ʹ��
                    GameObject a = GameObject.Instantiate(Item) as GameObject;
                    itemList.Add(a);
                    RectTransform t = itemList[i - 1].GetComponent<RectTransform>();  //��ȡǰһ�� item ��λ��                
                                                                                      //��ǰ item λ�÷�����ǰһ�� item �·�                
                    a.GetComponent<RectTransform>().localPosition = new Vector3(t.localPosition.x, t.localPosition.y - t.rect.height, t.localPosition.z);
                    a.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    i++;
                    GameObject planeName = a.transform.Find("PlaneName_text").gameObject;
                    GameObject TotalNum = a.transform.Find("TotalNum_text").gameObject;
                    GameObject UsingNum = a.transform.Find("Using_text").gameObject;
                    GameObject LeisureNum = a.transform.Find("LeisureNum_text").gameObject;
                    planeName.GetComponent<Text>().text = list[i].GetName();
                    TotalNum.GetComponent<Text>().text = GlobalVariable.planeDic[list[i]].ToString();
                    foreach (KeyValuePair<Plane, int> kvp in GlobalVariable.BusyPlanesDic)
                    {
                        if (kvp.Key.GetName() == planeName.GetComponent<Text>().text)
                        {
                            UsingNum.GetComponent<Text>().text = kvp.Value.ToString();
                            IsUse = 1;//�÷ɻ��б�ʹ��
                            break;
                        }
                    }
                    if(IsUse==0)
                    {
                        UsingNum.GetComponent<Text>().text = 0.ToString();
                    }
                    int Total = System.Convert.ToInt32(TotalNum.GetComponent<Text>().text);
                    int use = System.Convert.ToInt32(UsingNum.GetComponent<Text>().text);
                    LeisureNum.GetComponent<Text>().text = (Total - use).ToString();

                }
                
            }
        }*/
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
    public  void ShowAllPlane(List<Plane> planes)
    {
        if (planes.Count == 0)//没有可使用的飞机
        {
            Noneimage.SetActive(true);
        }
        else
        {

            for (int i = 0; i < planes.Count; i++)
            {
                Debug.Log(planes.Count);
                int IsUse = 0;//该飞机全都未被使用
                GameObject a = GameObject.Instantiate(Item) as GameObject;
                itemList.Add(a);
                //RectTransform t = itemList[i - 1].GetComponent<RectTransform>();  
                //a.GetComponent<RectTransform>().localPosition = new Vector3(t.localPosition.x, t.localPosition.y - t.rect.height, t.localPosition.z);
                //a.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                a.transform.localPosition = new Vector3(itemLocalPos.x, itemLocalPos.y - (i + 1) * 80, 0);
                Debug.Log(a.transform.localPosition);
                a.GetComponent<Transform>().SetParent(parent.GetComponent<Transform>(), false);
                GameObject planeName = a.transform.Find("PlaneName_text").gameObject;
                GameObject TotalNum = a.transform.Find("TotalNum_text").gameObject;
                GameObject UsingNum = a.transform.Find("Using_text").gameObject;
                GameObject LeisureNum = a.transform.Find("LeisureNum_text").gameObject;
                planeName.GetComponent<Text>().text = planes[i].GetName();
                Debug.Log(planes[i].GetName());
                TotalNum.GetComponent<Text>().text = GlobalVariable.planeDic[planes[i]].ToString();
                foreach (KeyValuePair<Plane, int> Bpd in GlobalVariable.BusyPlanesDic)
                {
                    if (Bpd.Key.GetName() == planeName.GetComponent<Text>().text)
                    {
                        UsingNum.GetComponent<Text>().text = Bpd.Value.ToString();
                        IsUse = 1;//该飞机有被使用
                        break;
                    }
                }
                if (IsUse == 0)
                {
                    UsingNum.GetComponent<Text>().text = 0.ToString();
                }
                int Total = System.Convert.ToInt32(TotalNum.GetComponent<Text>().text);
                int use = System.Convert.ToInt32(UsingNum.GetComponent<Text>().text);
                LeisureNum.GetComponent<Text>().text = (Total - use).ToString();

                if (contentSize.y <= itemList.Count * itemHeight)//增加内容高度
                {
                    parent.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSize.x, itemList.Count * itemHeight);
                }
            }
        }
    }


}
