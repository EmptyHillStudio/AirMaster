using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingPlanes : MonoBehaviour
{
    public static int Planes_num;
    public GameObject PlaneItem;//飞机每一条的项目，每一项的具体内容复制后都可以访问
    public GameObject Parent;//所有飞机项目的父级对象
    public GameObject PlanesBoard;//包含了滚动条在内的一整块对象
    public GameObject PrimaryText;//初始文本
    //刚开始时加载所有飞机并隐藏起来，显示初始文本
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
