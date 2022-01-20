using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{ //�������еĸ�������
    public int id;//���
    public string name;//������
    public float x;//γ��
    public float y;//����
    public string city_introduction;//���н���
    public float economy;//����ָ��
    public float tourism;//����ָ��

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
    public static void GetDistance(City c1, City c2)//������������
    {

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
}
