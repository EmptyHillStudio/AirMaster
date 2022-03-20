using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum City_Scale //���й�ģ����С��Ӣ��һ��
{
    TINY,
    SMALL,
    MIDDLE,
    LARGE,
    HUGE
}

public class City
{ //�������еĸ�������
    public int id;//���
    public string name;//������
    public string country;
    public float x;//γ��
    public float y;//����
    public string city_introduction;//���н���
    public float economy;//����ָ��
    public float tourism;//����ָ��
    public float personnel;//�˲�ָ��
    public bool begin;
    public bool end;
    public string getScale()
    {
        double fraction = Math.Round((economy + tourism) / 2, 2);
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
    public City(int id, string name, string country, float x, float y, float economy, float tourism)
    {
        this.id = id;
        this.name = name;
        this.country = country;
        this.x = x;
        this.y = y;
        this.economy = economy;
        this.tourism = tourism;
    }
    
    public string getName()
    {
        return this.name;
    }
    public static void GetDistance(City c1, City c2)//������������
    {

    }
    public void SetBegin(City city)
    {
        city.begin = true;
    }
    public void SetEnd(City city)
    {
        city.end = true;
    }
    public bool GetBegin()
    {
        return this.begin;
    }
    public bool Getend()
    {
        return this.end;
    }
    public void Reset()
    {
        this.begin = false;
        this.end = false;
    }
    public string GetCountry()
    {
        return this.country;
    }
}

public class CitiesManager
{//���г��еĹ��������ṩ��ȡ���е�һЩ����
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
    public City getBeginCity()
    {
        foreach (var c in Cities)
        {
            if (c.GetBegin() == true)
            {
                return c;
            }
        }
        return null;
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
}
