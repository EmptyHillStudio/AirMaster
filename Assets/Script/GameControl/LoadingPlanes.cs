using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingPlanes : MonoBehaviour
{
    public static int Planes_num;
    public GameObject PlaneItem;//�ɻ�ÿһ������Ŀ��ÿһ��ľ������ݸ��ƺ󶼿��Է���
    public GameObject Parent;//���зɻ���Ŀ�ĸ�������
    public GameObject PlanesBoard;//�����˹��������ڵ�һ�������
    public GameObject PrimaryText;//��ʼ�ı�
    //�տ�ʼʱ�������зɻ���������������ʾ��ʼ�ı�
    void Start()
    {
        Planes_num = 0;
        PlanesManager pManager = GlobalVariable.DefaultManager.planesManager;
        foreach (Plane p in pManager.GetPlanes())
        {
            Planes_num++;
            GameObject temp = GameObject.Instantiate(PlaneItem);
            GameObject Name = temp.transform.Find("Name").gameObject;
            GameObject Price = temp.transform.Find("Price").gameObject;
            GameObject Icon = temp.transform.Find("Icon").gameObject;
            Sprite logo = Resources.Load("Planes/" + p.series, typeof(Sprite)) as Sprite;
            string AllName;
            if (p.sub=="s")
            {
                AllName = p.series;
            }else AllName = p.series + "-" + p.sub;
            Icon.GetComponent<Image>().sprite = logo;
            temp.name = AllName;
            Name.GetComponent<Text>().text = AllName;
            Price.GetComponent<Text>().text = p.price.ToString();
            temp.transform.SetParent(Parent.transform);
            Date now = GlobalVariable.GameDate;
            temp.SetActive(false);
        }
        PlanesBoard.SetActive(false);
        PrimaryText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
