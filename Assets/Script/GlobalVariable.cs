using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//该类集合定义了多个需要用到的基础变量，可以直接使用

public class MathModel
{
    
}

public class GlobalVariable
{
    private PlayerPoints Money;
    private PlayerPoints Prestige;
    private PlayerPoints Personnel;
    private PlayerPoints ResearchPoints;

    public GlobalVariable()
    {
        
    }
    //全局时间戳，每帧会使时间戳加一
    public static Timer gTimer;

    //全局初始日期定义和相应的控制属性
    public static Date GameDate;
    public static bool IsPaused = true;
    public static bool Keep = true;
    public static int SpeedTime = 1;
    public static string CompanyName = "Debug Mode";

    //全局管理器
    public static InitManagers DefaultManager;
    //进入城市按钮将CityName传递
    public static string CityName;
    //记录Camera位置
    public static float fieldOfView=52F;
    public static float rx = 0f;
    public static float ry = 180f;
    public static float rz = 180f;
    public static float px = 0f;
    public static float py = -10f;
    public static float pz = 150f;
}

public class PlayerPoints
{
    /// <summary>
    /// 
    /// </summary>
    private double value;
    public double GetValue()
    {
        return this.value;
    }
    public PlayerPoints()
    {
        this.value = 0;
    }
    public PlayerPoints(double value)
    {
        this.value = value;
    }
    public PlayerPoints(int value)
    {
        this.value = (double)value;
    }
    public PlayerPoints(float value)
    {
        this.value = (double)value;
    }
    /// <summary>
    ///  对每个操作符进行定义，方便数值直接计算。
    /// </summary>
    /// <param name="p"></param>
    public static implicit operator int(PlayerPoints p)
    {
        return (int)p.GetValue();
    }
    public static implicit operator float(PlayerPoints p)
    {
        return (float)p.GetValue();
    }
    //+-PlayerPoints
    public static PlayerPoints operator +(PlayerPoints p1, PlayerPoints p2)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() + p2.GetValue();
        return plus;
    }
    public static PlayerPoints operator -(PlayerPoints p1, PlayerPoints p2)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() - p2.GetValue();
        return plus;
    }
    //+int,foat,double
    public static PlayerPoints operator +(PlayerPoints p1, int value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() + (double)value;
        return plus;
    }
    public static PlayerPoints operator +(PlayerPoints p1, float value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() + (double)value;
        return plus;
    }
    public static PlayerPoints operator +(PlayerPoints p1, double value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() + value;
        return plus;
    }
    //-int,float,double
    public static PlayerPoints operator -(PlayerPoints p1, int value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() - (double)value;
        return plus;
    }
    public static PlayerPoints operator -(PlayerPoints p1, float value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() - (double)value;
        return plus;
    }
    public static PlayerPoints operator -(PlayerPoints p1, double value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() - value;
        return plus;
    }
    // *int,float,double
    public static PlayerPoints operator *(PlayerPoints p1, int value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() * (double)value;
        return plus;
    }
    public static PlayerPoints operator *(PlayerPoints p1, float value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() * (double)value;
        return plus;
    }
    public static PlayerPoints operator *(PlayerPoints p1, double value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() * value;
        return plus;
    }
    // /int,float,double
    public static PlayerPoints operator /(PlayerPoints p1, int value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() / (double)value;
        return plus;
    }
    public static PlayerPoints operator /(PlayerPoints p1, float value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() / (double)value;
        return plus;
    }
    public static PlayerPoints operator /(PlayerPoints p1, double value)
    {
        PlayerPoints plus = new PlayerPoints();
        plus.value = p1.GetValue() / value;
        return plus;
    }
}