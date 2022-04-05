using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane
{
    public Company creater;//������
    public string model;//�ͺ�
    public string series;//ϵ��
    public string sub;//���ͺ�
    public PlaneSize Size;//��С
    public Date Launch;//����ʱ��
    public Date end;
    public int age;//�������
    public int mileage;//���
    public int capacity;//�ؿ���
    public int speed;//�ٶȣ��������Ƶķɻ���ϵͳ����
    public float price;//�ۼ�
    public int classes;//��λ����
    public float consumption;//�ͺ�
    public float depreciation;//�۾ɣ��������Ƶķɻ���ϵͳ����
    public Sprite icon;//�ɻ���ͼƬ
    public Plane(string creater, string model, string series, string sub, string Size, string launch, string age, string mileage, string speed, string capacity, string price, string classes, string consumption)
    {
        this.creater = GlobalVariable.DefaultManager.companiesManager.GetCompany(creater);
        this.model = model;
        this.series = series;
        //Debug.Log(series);
        this.sub = sub;
        //Debug.Log(Size);
        this.Size = GetSize(Size);
        //Debug.Log(this.Size.ToString());
        this.Launch = Date.FormatDate(launch);
        this.age = Convert.ToInt32(age);
        end = new Date(Launch.year + this.age, Launch.month, Launch.day);
        this.mileage = Convert.ToInt32(mileage);
        this.speed = Convert.ToInt32(speed);
        this.capacity = Convert.ToInt32(capacity);
        this.price = Convert.ToSingle(price);
        this.classes = Convert.ToInt32(classes);
        this.consumption = Convert.ToSingle(consumption);
        this.icon = Resources.Load<Sprite>("Planes/" + series);
    }
    public static PlaneSize GetSize(string size)
    {
        switch (size)
        {
            case "΢":
                return PlaneSize.TINY;
            case "С":
                return PlaneSize.SMALL;
            case "��":
                return PlaneSize.MIDDLE;
            case "��":
                return PlaneSize.BIG;
            case "��":
                return PlaneSize.HUGE;
            default:
                return PlaneSize.NULL;
        }
    }
    public string GetSeries()
    {
        return this.series;
    }
    public string GetSub()
    {
        return this.sub;
    }
    public string GetName()
    {
        return series + "-" + sub;
    }
}

public enum PlaneSize
{
    TINY,
    SMALL,
    MIDDLE,
    BIG,
    HUGE,
    NULL 
}

public class PlanesManager
{
    /// <summary>
    /// �Ѽ��طɻ��Ĺ����������ڴ������������еķɻ���
    /// </summary>
    private List<Plane> Planes;
    public Dictionary<string, Plane> CompanyPlanes;
    public PlanesManager()
    {
        GlobalVariable.planeDic = new Dictionary<Plane, int>();
        GlobalVariable.BusyPlanesDic = new Dictionary<Plane, int>();
        this.Planes = new List<Plane>();
        this.CompanyPlanes = new Dictionary<string, Plane>();
    }
    public void Add(Plane p)
    {
        this.Planes.Add(p);
        GlobalVariable.planeDic.Add(p, 0);

    }
    public List<Plane> GetPlanesByCompany(string CompanyName)
    {
        List<Plane> temp = new List<Plane>();
        foreach(Plane p in Planes)
        {
            if (CompanyName.Equals(p.creater.name))
            {
                temp.Add(p);
            }
        }
        return temp;
    }
    public List<Plane> GetPlanes()
    {
        return Planes;
    }
    //����ɻ�
    
    public void  buyPlane(Plane plane, int num)
    {
        int flag = 0;//����dic�ﲻ���ڸ÷ɻ�
        Dictionary<Plane, int>.KeyCollection keyCol = GlobalVariable.planeDic.Keys;
        foreach(Plane key in keyCol)
        {
            string keyId = key.GetSeries() + "-" + key.GetSub();
            string planeId = plane.GetSeries() + "-" + plane.GetSub();
            if (keyId == planeId)
            {
                GlobalVariable.planeDic[plane] += num;
                flag = 1;//dic����plane
            }
        }
        if(flag==0)
        {
            GlobalVariable.planeDic.Add(plane, num);
        }
    }
    
}
