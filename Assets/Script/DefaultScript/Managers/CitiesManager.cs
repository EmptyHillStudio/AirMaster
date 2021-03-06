using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum City_Scale //城市规模，大小和英文一样
{
    TINY,
    SMALL,
    MIDDLE,
    LARGE,
    HUGE
}

public class City
{ //单个城市的各项数据
    public int id;//编号
    public string name;//城市名
    public string country;
    public float x;//纬度
    public float y;//经度
    public string city_introduction;//城市介绍
    public float economy;//经济指数
    public float tourism;//旅游指数
    public float personnel;//人才指数
    public Sprite ScaleImage;//规模或特征图像
    public City_Scale Scale { set; get; }
    public string GetScaleString()
    {
        double fraction = Math.Round((economy + 1.2 * tourism + 0.8 * personnel) / 3, 2);
        if (fraction < 350)
        {
            return City_Scale.TINY.ToString();
        }
        else if (fraction < 450)
        {
            return City_Scale.SMALL.ToString();
        }
        else if (fraction < 500)
        {
            return City_Scale.MIDDLE.ToString();
        }
        else if (fraction < 550)
        {
            return City_Scale.LARGE.ToString();
        }
        else return City_Scale.HUGE.ToString();
    }
    public City_Scale GetScale()
    {
        double fraction = Math.Round((economy + 1.2 * tourism + 0.8 * personnel) / 3, 2);
        if (fraction < 350)
        {
            return City_Scale.TINY;
        }
        else if (fraction < 450)
        {
            return City_Scale.SMALL;
        }
        else if (fraction < 500)
        {
            return City_Scale.MIDDLE;
        }
        else if (fraction < 550)
        {
            return City_Scale.LARGE;
        }
        else return City_Scale.HUGE;
    }
    public City(int id, string name, string country, float x, float y, float economy, float tourism, float personnel)
    {
        this.id = id;
        this.name = name;
        this.country = country;
        this.x = x;
        this.y = y;
        this.economy = economy;
        this.tourism = tourism;
        this.personnel = personnel;
        this.Scale = this.GetScale();
        this.ScaleImage = CitiesManager.GetCitySprite(this);
    }
    
    public string getName()
    {
        return this.name;
    }
    public static float Earth_R = 6371f;
    public static double GetDistance(City c1, City c2)//计算两点间距离
    {
        double lat1 = double.Parse(c1.x.ToString());
        double lat2 = double.Parse(c2.x.ToString());
        double lon1 = double.Parse(c1.y.ToString());
        double lon2 = double.Parse(c2.y.ToString());
        double del1 = Math.Round(Math.Abs(lat1 -lat2),2);//lat
        double del2 = Math.Round(Math.Abs(lon1 - lon2), 2); ;//lon
        //Debug.Log("Del_Lat = " + del1 + "Del_Lon = " + del2);
        double dis = Math.Acos(Math.Cos(lat1)*Math.Cos(lat2)*Math.Cos(del2)+Math.Sin(lat1)*Math.Sin(lat2));
        dis = Math.Round(dis * Earth_R, 2);
        return dis;
    }
    public string GetCountry()
    {
        return this.country;
    }
    
}

public class CitiesManager
{//所有城市的管理器，提供获取城市的一些方法
    public static string DefaultImagePath = "CityThumbnail/Default";
    public static string SpecialImagePath = "CityThumbnail/Special";
    public static Dictionary<string, Sprite> ScaleImageManager;
    public static Dictionary<City_Scale, Sprite> DefaultImage;
    List<City> Cities;
    public CitiesManager()
    {
        ScaleImageManager = new Dictionary<string, Sprite>();
        DefaultImage = new Dictionary<City_Scale, Sprite>();
        object[] images = Resources.LoadAll(DefaultImagePath);
        foreach(object i in images)
        {
            Sprite s;
            try
            {
                //Debug.Log("it's " + i.ToString());
                s = (Sprite)i;
            }
            catch(Exception)
            {
                continue;
                //Nothing
            }
            DefaultImage.Add(GetScaleByNumber(s.name), s);
        }
        images = Resources.LoadAll(SpecialImagePath);
        foreach (object i in images)
        {
            Sprite s;
            try
            {
                //Debug.Log("it's " + i.ToString());
                s = (Sprite)i;
            }
            catch (Exception)
            {
                continue;
                //Nothing
            }
            ScaleImageManager.Add(s.name, s);
        }

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

    public static Sprite GetCitySprite(City c)
    {
        if (ScaleImageManager.ContainsKey(c.name))
        {
            return ScaleImageManager[c.name];
        }
        else return DefaultImage[c.Scale];
    }

    public void add(City c)
    {
        this.Cities.Add(c);
    }
    public List<City> GetCityListByCountryName(string name)
    {
        List<City> allCities = new List<City>();
        foreach (var c in Cities)
        {
            if(c.GetCountry().Equals(name))
            {
                allCities.Add(c);
            }
        }
        return allCities;
    }
    public static City_Scale GetScaleByNumber(string num)
    {
        switch (num)
        {
            case "2":
                return City_Scale.SMALL;
            case "3":
                return City_Scale.MIDDLE;
            case "4":
                return City_Scale.LARGE;
            case "5":
                return City_Scale.HUGE;
            default:
                return City_Scale.TINY;
        }
    }
}
