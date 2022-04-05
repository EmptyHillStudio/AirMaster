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
    public Date end;
    public int age;//出售年间
    public int mileage;//里程
    public int capacity;//载客量
    public int speed;//速度，自主研制的飞机靠系统计算
    public float price;//售价
    public int classes;//舱位级数
    public float consumption;//油耗
    public float depreciation;//折旧，自主研制的飞机靠系统计算
    public Sprite icon;//飞机的图片
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
    /// 已加载飞机的管理器，用于储存所有数据中的飞机。
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
    //购买飞机
    
    public void  buyPlane(Plane plane, int num)
    {
        int flag = 0;//表明dic里不存在该飞机
        Dictionary<Plane, int>.KeyCollection keyCol = GlobalVariable.planeDic.Keys;
        foreach(Plane key in keyCol)
        {
            string keyId = key.GetSeries() + "-" + key.GetSub();
            string planeId = plane.GetSeries() + "-" + plane.GetSub();
            if (keyId == planeId)
            {
                GlobalVariable.planeDic[plane] += num;
                flag = 1;//dic里有plane
            }
        }
        if(flag==0)
        {
            GlobalVariable.planeDic.Add(plane, num);
        }
    }
    
}
