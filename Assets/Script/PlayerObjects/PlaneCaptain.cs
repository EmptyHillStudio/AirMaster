using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCaptain
{
    //机长对象，表示某机长的各项能力和数值。
    public string name;
    public int age;
    public string sex;
    public string country;
    public double flight_duration;//飞行时长
    public double Calmnessness;//冷静度
    public double Professionssional;//专业度
    public double execution;//执行力
    public double learning;//学习力
    public double r_p;//身心素质
    public double languages;//外语水平
    public double effect;//影响力
    public double morality;//道德

    public PlaneCaptain()
    {

    }

    public void Info()
    {
        Type type = typeof(PlaneCaptain);
        FieldInfo[] fields = type.GetFields();
        foreach (FieldInfo field in fields)
        {
            Debug.Log(field.Name + ":  " + field.GetValue(this));
        }
    }

    //通过固定分数添加机长，添加机长操作会把机长移入机长管理器。
    public static PlaneCaptain GetPointsPlaneCaptain(float points)
    {
        PlaneCaptain temp = new PlaneCaptain();
        List<string> countries = GlobalVariable.DefaultManager.countriesManager.countriesName;
        int random = UnityEngine.Random.Range(0, countries.Count);
        temp.country = countries[random];//后期再出国家生成概率分布，目前暂时用均匀分布。
        temp.name = "TestName";//暂时还未完成随机姓名生成器。
        float random_f = UnityEngine.Random.Range(0f, 1f);
        string sex;
        if (random_f <= 0.9)
        {
            sex = "male";
        }
        else sex = "female";
        temp.sex = sex;
        temp.age = UnityEngine.Random.Range(PlaneCaptainParameter.minAge, PlaneCaptainParameter.maxAge);
        double points_AfterAged = points / PlaneCaptainParameter.agePercentage[temp.age];
        double[] random_range = new double[2];
        random_range[0] = -points_AfterAged * 0.1;
        random_range[1] = points_AfterAged * 0.1;
        //偷懒用反射实现成员遍历
        Type type = typeof(PlaneCaptain);
        FieldInfo[] properties = type.GetFields();
        foreach (FieldInfo prop in properties)
        {
            if (prop.FieldType == typeof(Double))
            {
                double per = 0;
                if (prop.Name == "flight_duration")
                {
                    per = 0.52;//飞行时长占比0.5
                }
                else if (prop.Name == "languages"|| prop.Name == "morality" || prop.Name == "morality")
                {
                    per = 0.04;//这三项总占比0.09
                }else
                {
                    per = 0.08;//剩下的5项因素共占比0.3
                }
                //生成随机小数
                random_range[0] = Math.Round(random_range[0] * per, 2);
                random_range[1] = Math.Round(random_range[1] * per, 2);
                //Debug.Log("Range: [" + random_range[0] + " , " + random_range[1] + "]");//范围调试
                double random_del = UnityEngine.Random.Range(float.Parse(random_range[0].ToString()), float.Parse(random_range[1].ToString()));
                //范围整体移动
                random_range[0] -= random_del;
                random_range[1] -= random_del;
                random_range[0] = Math.Round(random_range[0] / per, 2);
                random_range[1] = Math.Round(random_range[1] / per, 2);
                double Value = Math.Round(points_AfterAged * per + random_del, 2);
                prop.SetValue(temp, Value);
            }
        }
        GlobalVariable.DefaultManager.planeCaptainsManager.Add(temp);
        return temp;
    }

    //通过固定城市添加机长，添加机长操作会把机长移入机长管理器。
    public static PlaneCaptain GetRandomPlaneCaptain(float investmentlevel, City c)
    {
        PlaneCaptain temp = new PlaneCaptain();
        List<string> countries = GlobalVariable.DefaultManager.countriesManager.countriesName;
        int random = UnityEngine.Random.Range(0, countries.Count);
        temp.country = countries[random];//后期再出国家生成概率分布，目前暂时用均匀分布。
        temp.name = "TestName";//暂时还未完成随机姓名生成器。
        float random_f = UnityEngine.Random.Range(0f, 1f);
        string sex;
        if (random_f <= 0.9)
        {
            sex = "male";
        }
        else sex = "female";
        temp.sex = sex;
        //Debug.Log("sex: " + sex);
        temp.age = UnityEngine.Random.Range(PlaneCaptainParameter.minAge, PlaneCaptainParameter.maxAge);
        //Debug.Log("age: " + age);
        double random_d = PlaneCaptainParameter.FlightDurationrandom * UnityEngine.Random.Range(0, 100);
        double flight_duration = (double)investmentlevel * PlaneCaptainParameter.FlightDurationlevel + (double)c.personnel * PlaneCaptainParameter.FlightDurationpersonnel + random_d;
        flight_duration *= 1000;
        temp.flight_duration = ((double)flight_duration) / 100;
        //Debug.Log("flight_duration: " + flight_duration);
        random_d = PlaneCaptainParameter.Calmnessrandom * UnityEngine.Random.Range(0, 100);
        double Calmnessness = (int)investmentlevel * PlaneCaptainParameter.Calmnesslevel + (double)c.personnel * PlaneCaptainParameter.Calmnesspersonnel + random_d;
        temp.Calmnessness = (double)(int)Calmnessness;
        //Debug.Log("Calmnessness: " + Calmnessness);
        random_d = PlaneCaptainParameter.Professionrandom * UnityEngine.Random.Range(0, 100);
        double Profession = (double)investmentlevel * PlaneCaptainParameter.Professionlevel + (double)c.personnel * PlaneCaptainParameter.Professionpersonnel + random_d;
        temp.Professionssional = (double)(int)Profession;
        //Debug.Log("Profession: " + Profession);
        random_d = PlaneCaptainParameter.Executionrandom * UnityEngine.Random.Range(0, 100);
        double Execution = (double)investmentlevel * PlaneCaptainParameter.Executionlevel + (double)c.personnel * PlaneCaptainParameter.Executionpersonnel + random_d;
        temp.execution = (double)(int)Execution;
        //Debug.Log("Execution: " + Execution);
        random_d = PlaneCaptainParameter.Learningrandom * UnityEngine.Random.Range(0, 100);
        double Learning = (double)investmentlevel * PlaneCaptainParameter.Learninglevel + (double)c.personnel * PlaneCaptainParameter.Learningpersonnel + random_d;
        temp.learning = (double)(int)Learning;
        //Debug.Log("Learning: " + Learning);
        random_d = PlaneCaptainParameter.RnPrandom * UnityEngine.Random.Range(0, 100);
        double RnP = (double)investmentlevel * PlaneCaptainParameter.RnPlevel + (double)c.personnel * PlaneCaptainParameter.RnPpersonnel + random_d;
        temp.r_p = (double)(int)RnP;
        //Debug.Log("RnP: " + RnP);
        random_d = PlaneCaptainParameter.Languagerandom * UnityEngine.Random.Range(0, 100);
        double Language = (double)investmentlevel * PlaneCaptainParameter.Languagelevel + (double)c.personnel * PlaneCaptainParameter.Languagepersonnel + random_d;
        temp.languages = (double)(int)Language;
        //Debug.Log("Language: " + Language);
        random_d = PlaneCaptainParameter.Effectrandom * UnityEngine.Random.Range(0, 100);
        double Effect = (double)investmentlevel * PlaneCaptainParameter.Effectlevel + (double)c.personnel * PlaneCaptainParameter.Effectpersonnel + random_d;
        temp.effect = (double)(int)Effect;
        //Debug.Log("Effect: " + Effect);
        random_d = PlaneCaptainParameter.Moralityrandom * UnityEngine.Random.Range(0, 100);
        double Morality = (double)investmentlevel * PlaneCaptainParameter.Moralitylevel + (double)c.personnel * PlaneCaptainParameter.Moralitypersonnel + random_d;
        temp.morality = (double)(int)Morality;
        //Debug.Log("Morality: " + Morality);
        GlobalVariable.DefaultManager.planeCaptainsManager.Add(temp);
        return temp;
    }
}
public class PlaneCaptainParameter
{
    public static Dictionary<int, double> agePercentage;
    public static int minAge;
    public static int maxAge;
    public static int Isini;
    //Flight duration
    public static double FlightDurationlevel;
    public static double FlightDurationpersonnel;
    public static double FlightDurationrandom;
    //Calmnessness
    public static double Calmnesslevel;
    public static double Calmnesspersonnel;
    public static double Calmnessrandom;
    public static double Calmnesst;
    public static double Calmnesslearn;
    //Professionssion
    public static double Professionlevel = 10;
    public static double Professionpersonnel = 0.1;
    public static double Professionrandom = 0.2;
    public static double Professioninvestment = 0.0001;
    public static double Professionmaxgrow = 20;
    //Execution
    public static double Executionlevel = 10;
    public static double Executionpersonnel = 0.1;
    public static double Executionrandom = 0.2;
    public static double Executioninvestment = 0.0001;
    public static double Executionmaxgrow = 20;
    //学习能力，参数作用同上
    //Learning
    public static double Learninglevel = 10;
    public static double Learningpersonnel = 0.1;
    public static double Learningrandom = 0.5;
    //身心素质，t为每年衰减值，min为该数值的最小值
    //RnP
    public static double RnPlevel = 10;
    public static double RnPpersonnel = 0.1;
    public static double RnPrandom = 0.2;
    public static double RnPt = 1;
    public static double RnPmin = 30;
    //下面是其他因素的各项参数
    //语言能力，参数作用同专业度
    //Language
    public static double Languagelevel = 10;
    public static double Languagepersonnel = 0.1;
    public static double Languagerandom = 0.2;
    public static double Languageinvestment = 0.0002;
    public static double Languagemaxgrow = 30;
    //影响力，prob为每个月增加的概率，range为增加值的范围
    //Effect
    public static double Effectlevel = 10;
    public static double Effectpersonnel = 0.1;
    public static double Effectrandom = 0.2;
    public static double Effectprob = 0.2;
    public static double Effectrange = 5;
    public static double Effectmaxgrow = 30;
    //道德值，参数作用同学习能力
    //Morality
    public static double Moralitylevel = 20;
    public static double Moralitypersonnel = 0.05;
    public static double Moralityrandom = 0.3;
}
