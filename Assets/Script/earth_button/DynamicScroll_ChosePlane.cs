using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicScroll_ChosePlane : MonoBehaviour
{
    private static PlanesManager planemanager;
    public GameObject Item;
    public GameObject Content;
    public GameObject Noneimage;
    public GameObject ChoseImage;
    List<GameObject> itemList = new List<GameObject>();
    void Start()
    {
        if (GlobalVariable.planeDic == null)
        {
            Debug.Log("null");
            Noneimage.SetActive(true);
            ChoseImage.SetActive(false);
        }
        else
        {
            List<Plane> list = new List<Plane>(GlobalVariable.planeDic.Keys);
            int _count = GlobalVariable.BusyPlanesDic.Count;
            Debug.Log(_count);
            //����֮ǰ�����ɵ�item������б�
            itemList.Clear();

            //�� Content ������ _count ��item
            if (_count > 0)
            {
                Item.SetActive(true);   //��һ��itemʵ���Ѿ������б��һ��λ�ã�ֱ�Ӽ���
                itemList.Add(Item);
                int i = 1;

                while (i < _count)
                {
                    GameObject a = GameObject.Instantiate(Item) as GameObject;
                    a.transform.parent = Content.transform;  //����Ϊ Content ���Ӷ���
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
                            break;
                        }
                    }
                    int Total = System.Convert.ToInt32(TotalNum.GetComponent<Text>().text);
                    int use = System.Convert.ToInt32(UsingNum.GetComponent<Text>().text);
                    LeisureNum.GetComponent<Text>().text = (Total - use).ToString();

                }
                //���ݵ�ǰ item �������� Content �߶� 
                Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x, itemList.Count * 80);
            }
            else
            {
                Item.SetActive(false);
            }
        }
    }
}
