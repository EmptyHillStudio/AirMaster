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
    //全局数据文件夹目录
    public static string DataFile = Application.streamingAssetsPath;
    public static string LoadFile = Application.persistentDataPath;
    //全局玩家数据
    private PlayerPoints Money;
    private PlayerPoints Prestige;
    private PlayerPoints Personnel;
    private PlayerPoints ResearchPoints;

    //全局参数

    //参数和配置读取，建议点击左下角的那个减号收起来
    public GlobalVariable()
    {
        //读取基本配置文件
        Debug.Log("Loading configure files....");

        string configFile = DataFile + "/DefaultConfigure";
        INIParser ini = new INIParser();

        //读取机长参数配置文件
        ini.Open(configFile + "/PlaneCaptain.ini");//string ReadValue(string section, string key, string default)
        PlaneCaptainParameter.minAge = Convert.ToInt32(ini.ReadValue("Age", "min", "18"));
        PlaneCaptainParameter.maxAge = Convert.ToInt32(ini.ReadValue("Age", "min", "41"));
        PlaneCaptainParameter.Isini = Convert.ToInt32(ini.ReadValue("Age", "Isini", "0"));
        PlaneCaptainParameter.FlightDurationlevel = Convert.ToDouble(ini.ReadValue("Flight Duration", "level", "10"));
        PlaneCaptainParameter.FlightDurationpersonnel = Convert.ToDouble(ini.ReadValue("Flight Duration", "personnel", "0.1")); 
        PlaneCaptainParameter.FlightDurationrandom = Convert.ToDouble(ini.ReadValue("Flight Duration", "random", "0.2"));
        //Calmnessness
        PlaneCaptainParameter.Calmnesslevel = Convert.ToDouble(ini.ReadValue("Calmness", "level", "10")); 
        PlaneCaptainParameter.Calmnesspersonnel = Convert.ToDouble(ini.ReadValue("Calmness", "personnel", "0.1"));
        PlaneCaptainParameter.Calmnessrandom = Convert.ToDouble(ini.ReadValue("Calmness", "random", "0.2"));
        PlaneCaptainParameter.Calmnesst = Convert.ToDouble(ini.ReadValue("Calmness", "t", "3"));
        PlaneCaptainParameter.Calmnesslearn = Convert.ToDouble(ini.ReadValue("Calmness", "learn", "0.01"));
        //Professionssion
        PlaneCaptainParameter.Professionlevel = Convert.ToDouble(ini.ReadValue("Profession", "level", "10"));
        PlaneCaptainParameter.Professionpersonnel = Convert.ToDouble(ini.ReadValue("Profession", "personnel", "0.1"));
        PlaneCaptainParameter.Professionrandom = Convert.ToDouble(ini.ReadValue("Profession", "random", "0.2"));
        PlaneCaptainParameter.Professioninvestment = Convert.ToDouble(ini.ReadValue("Profession", "investment", "0.0001"));
        PlaneCaptainParameter.Professionmaxgrow = Convert.ToDouble(ini.ReadValue("Profession", "maxgrow", "20"));
        //Execution
        PlaneCaptainParameter.Executionlevel = Convert.ToDouble(ini.ReadValue("Execution", "level", "10"));
        PlaneCaptainParameter.Executionpersonnel = Convert.ToDouble(ini.ReadValue("Execution", "personnel", "0.1"));
        PlaneCaptainParameter.Executionrandom = Convert.ToDouble(ini.ReadValue("Execution", "random", "0.2"));
        PlaneCaptainParameter.Executioninvestment = Convert.ToDouble(ini.ReadValue("Execution", "investment", "0.0001"));
        PlaneCaptainParameter.Executionmaxgrow = Convert.ToDouble(ini.ReadValue("Execution", "maxgrow", "20"));
        //学习能力，参数作用同上
        //Learning
        PlaneCaptainParameter.Learninglevel = Convert.ToDouble(ini.ReadValue("Learning", "level", "10"));
        PlaneCaptainParameter.Learningpersonnel = Convert.ToDouble(ini.ReadValue("Learning", "personnel", "0.1"));
        PlaneCaptainParameter.Learningrandom = Convert.ToDouble(ini.ReadValue("Learning", "random", "0.5"));
        //身心素质，t为每年衰减值，min为该数值的最小值
        //RnP
        PlaneCaptainParameter.RnPlevel = Convert.ToDouble(ini.ReadValue("RnP", "level", "10"));
        PlaneCaptainParameter.RnPpersonnel = Convert.ToDouble(ini.ReadValue("RnP", "personnel", "0.1"));
        PlaneCaptainParameter.RnPrandom = Convert.ToDouble(ini.ReadValue("RnP", "random", "0.2"));
        PlaneCaptainParameter.RnPt = Convert.ToDouble(ini.ReadValue("RnP", "t", "1"));
        PlaneCaptainParameter.RnPmin = Convert.ToDouble(ini.ReadValue("RnP", "min", "30"));
        //下面是其他因素的各项参数
        //语言能力，参数作用同专业度
        //Language
        PlaneCaptainParameter.Languagelevel = Convert.ToDouble(ini.ReadValue("Language", "level", "10"));
        PlaneCaptainParameter.Languagepersonnel = Convert.ToDouble(ini.ReadValue("Language", "personnel", "0.1"));
        PlaneCaptainParameter.Languagerandom = Convert.ToDouble(ini.ReadValue("Language", "random", "0.2"));
        PlaneCaptainParameter.Languageinvestment = Convert.ToDouble(ini.ReadValue("Language", "investment", "0.0001"));
        PlaneCaptainParameter.Languagemaxgrow = Convert.ToDouble(ini.ReadValue("Language", "maxgrow", "20"));
        //影响力，prob为每个月增加的概率，range为增加值的范围
        //Effect
        PlaneCaptainParameter.Effectlevel = Convert.ToDouble(ini.ReadValue("Effect", "level", "10"));
        PlaneCaptainParameter.Effectpersonnel = Convert.ToDouble(ini.ReadValue("Effect", "personnel", "0.1"));
        PlaneCaptainParameter.Effectrandom = Convert.ToDouble(ini.ReadValue("Effect", "random", "0.2"));
        PlaneCaptainParameter.Effectprob = Convert.ToDouble(ini.ReadValue("Effect", "prob", "0.2"));
        PlaneCaptainParameter.Effectrange = Convert.ToDouble(ini.ReadValue("Effect", "range", "5"));
        PlaneCaptainParameter.Effectmaxgrow = Convert.ToDouble(ini.ReadValue("Effect", "maxgrow", "30"));
        //道德值，参数作用同学习能力
        //Morality
        PlaneCaptainParameter.Moralitylevel = Convert.ToDouble(ini.ReadValue("Morality", "level", "10"));
        PlaneCaptainParameter.Moralitypersonnel = Convert.ToDouble(ini.ReadValue("Morality", "personnel", "0.1"));
        PlaneCaptainParameter.Moralityrandom = Convert.ToDouble(ini.ReadValue("Morality", "random", "0.5"));
        ini.Close();

        PlaneCaptainParameter.agePercentage = DataLoader.GetDistribution();
        if (PlaneCaptainParameter.Isini==1)
        {
            Debug.Log("Configure files is loaded.");
        }else
        {
            Debug.Log("There are something wrong in " + configFile + "PlaneCaptain.ini");
        }
        
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