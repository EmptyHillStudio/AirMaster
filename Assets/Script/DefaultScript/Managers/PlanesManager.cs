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
    public int age;//�������
    public int mileage;//���
    public int capacity;//�ؿ���
    public int speed;//�ٶȣ��������Ƶķɻ���ϵͳ����
    //public Company manufacturer; //������
    public float price;//�ۼ�
    public int classes;//��λ����
    public float consumption;//�ͺ�
    public float depreciation;//�۾ɣ��������Ƶķɻ���ϵͳ����
    public Image icon;//�ɻ���ͼƬ
    public Plane(string creater, string model, string series, string sub, string Size, string launch, string age, string mileage, string speed, string capacity, string price, string classes, string consumption)
    {
        this.creater = GlobalVariable.DefaultManager.companiesManager.GetCompany(creater);
        this.model = model;
        this.series = series;
        Debug.Log(series);
        this.sub = sub;
        this.Size = GetSize(Size);
        this.Launch = Date.FormatDate(launch);
        this.age = Convert.ToInt32(age);
        this.mileage = Convert.ToInt32(mileage);
        this.speed = Convert.ToInt32(speed);
        this.capacity = Convert.ToInt32(capacity);
        this.price = Convert.ToSingle(price);
        this.classes = Convert.ToInt32(classes);
        this.consumption = Convert.ToSingle(consumption);
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
    private List<Plane> Planes;
    public PlanesManager()
    {
        this.Planes = new List<Plane>();
    }
    public void Add(Plane p)
    {
        this.Planes.Add(p);
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
}
