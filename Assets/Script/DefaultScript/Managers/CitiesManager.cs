using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{ //单个城市的各项数据
    private string name;
    private float x;
    private float y;
    private string city_introduction;
    public City(string name, float x, float y)
    {
        this.name = name;
        this.x = x;
        this.y = y;
    }
    public string getName()
    {
        return this.name;
    }
    float getX()
    {
        return x;
    }
    float getY()
    {
        return y;
    }
    public static void GetDistance(City c1, City c2)
    {

    }
    public static void GetTicketIn(City c1,City c2)
    {

    }
    public string getIntroduction()
    {
        return this.city_introduction;
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
