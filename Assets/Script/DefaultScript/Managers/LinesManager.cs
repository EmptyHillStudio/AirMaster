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
    private City[] Points; //���������ʾ�����к��յ���У���ת���������飬�涨0��ʾ��㣬1��ʾ�յ㡣
    public double distance; //���߳���
    public double real_distance;
    public bool IsTemp; //��ȷ�ϴ���ǰ��boolֵΪtrue����ʾΪ��ʱ����������ʱ����ݸ�boolֵ�����Ƿ�ɾ���ú��ߣ������ɾ�������LinesManager�С�
    public List<Service> services; //�������׷���
    public Plane usingPlane;//����ʹ�õķɻ�
    public PlaneCaptain captain;//�����ϵĻ���
    public bool FuelSton;//�̶�ȼ��
    public bool CheckSlu;//��ǿ���
    public bool Priority;//��������
    /*
     * ���ݲ߻�����ѧģ���ٶ���͹���ÿ�����ߵĸ����Ա����������
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
{//���߹��������ṩ���Ӻ��ߺ�ͨ����ַ��ȡ���ߵȽӿ�
    public int id = 0;//ȫ�ֺ���id����0��ʼ��ÿ�η�����1�����⺽���ظ���ɾ���������Ӧ��id����������
    private List<Line> Lines;
    public LinesManager()
    {
        this.Lines = new List<Line>();

    }
    public void Add(City begin, City end)//���Ӻ���
    {
        Line line = new Line(id, begin, end);
        this.Lines.Add(line);
        id++;
    }
    public void remove(int id)
    {

    }
    public List<Line> getBeginCityLines(City city)//��ȡ��cityΪ�������к��ߣ�����һ��List
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
