using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane
{
    public Company creater;//制造商
    public string model;//型号
    public string series;//系列
    public string sub;//副型号
    public PlaneSize Size;//大小
    public Date Launch;//发售时间
    public int age;//出售年间
    public int mileage;//里程
    public int capacity;//载客量
    public int speed;//速度，自主研制的飞机靠系统计算
    //public Company manufacturer; //生产商
    public float price;//售价
    public int classes;//舱位级数
    public float consumption;//油耗
    public float depreciation;//折旧，自主研制的飞机靠系统计算
    public Image icon;//飞机的图片
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
            case "微":
                return PlaneSize.TINY;
            case "小":
                return PlaneSize.SMALL;
            case "中":
                return PlaneSize.MIDDLE;
            case "大":
                return PlaneSize.BIG;
            case "巨":
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
