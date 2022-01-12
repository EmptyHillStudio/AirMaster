using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    private int id;
    public City[] Points; //城市数组表示起点城市和终点城市，中转航线再商议，规定0表示起点，1表示终点。
    public float distance; //航线长度
    //public List<Service> services; //航线配套服务，目前还未定义Service类
    /*
     * 根据策划和数学模型再定义和构建每条航线的各项成员变量和属性
     */
    public string info;
    public Line(int id, City begin, City end)
    {
        this.Points[0] = begin;
        this.Points[1] = end;
    }
}

public class LinesManager
{//航线管理器，提供增加航线和通过地址获取航线等接口
    private int id = 0;//全局航线id，从0开始，每次分配后加1，避免航线重复。删除航线则对应的id将不复存在
    private List<Line> Lines;
    public LinesManager()
    {
        this.Lines = new List<Line>();

    }
    public void add(City begin, City end)//增加航线
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
            if (line.Points[0].getName() == city.getName())
            {
                temp.Add(line);
            }
        }
        return temp;
    }
}
