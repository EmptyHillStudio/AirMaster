using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreatingState
{
    CREATING,
    CONFIRMED,
    CANCEL
}

public class Line
{
    private int id;
    private City[] Points; //城市数组表示起点城市和终点城市，中转航线再商议，规定0表示起点，1表示终点。
    public double distance; //航线长度
    public double real_distance;
    public bool IsTemp; //在确认创建前该bool值为true，表示为临时创建，返回时会根据该bool值决定是否删除该航线，如果不删除则加入LinesManager中。
    public List<Service> services; //航线配套服务
    public Plane usingPlane;//航线使用的飞机
    public PlaneCaptain captain;//航线上的机长
    public bool FuelSton;//固定燃油
    public bool CheckSlu;//加强检查
    public bool Priority;//优先廊桥
    /*
     * 根据策划和数学模型再定义和构建每条航线的各项成员变量和属性
     */
    public string info;
    public Line(int id, City begin, City end)
    {
        IsTemp = true;
        Points = new City[2];
        this.Points[0] = begin;
        this.Points[1] = end;
    }
    public Line(int id)
    {
        Points = new City[2];
    }
    public void SetPoints(int i, City c)
    {
        Points[i] = c;
        if (Points[0] != null && Points[1] != null) 
        {
            this.distance = GetDistance();
            this.real_distance = Math.Round(1.2 * distance, 2);
        }
    }
    public double GetDistance()
    {
        return City.GetDistance(Points[0], Points[1]);
    }
    public City[] GetPoints()
    {
        return Points;
    }
}

public class LinesManager
{//航线管理器，提供增加航线和通过地址获取航线等接口
    public int id = 0;//全局航线id，从0开始，每次分配后加1，避免航线重复。删除航线则对应的id将不复存在
    private List<Line> Lines;
    public LinesManager()
    {
        this.Lines = new List<Line>();

    }
    public void Add(City begin, City end)//增加航线
    {
        Line line = new Line(id, begin, end);
        this.Lines.Add(line);
        id++;
    }
    public void remove(int id)
    {

    }
    public List<Line> getBeginCityLines(City city)//获取以city为起点的所有航线，返回一个List
    {
        List<Line> temp = new List<Line>();
        foreach(Line line in Lines)
        {
            if (line.GetPoints()[0].getName() == city.getName())
            {
                temp.Add(line);
            }
        }
        return temp;
    }
}
