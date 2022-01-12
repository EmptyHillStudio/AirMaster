using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    private int id;
    public City[] Points; //���������ʾ�����к��յ���У���ת���������飬�涨0��ʾ��㣬1��ʾ�յ㡣
    public float distance; //���߳���
    //public List<Service> services; //�������׷���Ŀǰ��δ����Service��
    /*
     * ���ݲ߻�����ѧģ���ٶ���͹���ÿ�����ߵĸ����Ա����������
     */
    public string info;
    public Line(int id, City begin, City end)
    {
        this.Points[0] = begin;
        this.Points[1] = end;
    }
}

public class LinesManager
{//���߹��������ṩ���Ӻ��ߺ�ͨ����ַ��ȡ���ߵȽӿ�
    private int id = 0;//ȫ�ֺ���id����0��ʼ��ÿ�η�����1�����⺽���ظ���ɾ���������Ӧ��id����������
    private List<Line> Lines;
    public LinesManager()
    {
        this.Lines = new List<Line>();

    }
    public void add(City begin, City end)//���Ӻ���
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
            if (line.Points[0].getName() == city.getName())
            {
                temp.Add(line);
            }
        }
        return temp;
    }
}
