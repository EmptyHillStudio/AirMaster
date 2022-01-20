using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{ //单个城市的各项数据
    public int id;//编号
    public string name;//城市名
    public float x;//纬度
    public float y;//经度
    public string city_introduction;//城市介绍
    public float economy;//经济指数
    public float tourism;//旅游指数

    public City(int id, string name, float x, float y, float economy, float tourim)
    {
        this.id = id;
        this.name = name;
        this.x = x;
        this.y = y;
        this.economy = economy;
        this.tourism = tourism;
    }
    public string getName()
    {
        return this.name;
    }
    public static void GetDistance(City c1, City c2)//计算两点间距离
    {

    }
}

public class CitiesManager
{//所有城市的管理器，提供获取城市的一些方法
    List<City> Cities;
    public CitiesManager()
    {
        this.Cities = new List<City>();
    }
    public City getCityByName(string name)
    {
        foreach(var c in Cities)
        {
            if (name.Equals(c.getName()))
            {
                return c;
            }
        }
        return null;
    }
    public void add(City c)
    {
        this.Cities.Add(c);
    }
}
