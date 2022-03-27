using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCaptain
{
    //�������󣬱�ʾĳ�����ĸ�����������ֵ��
    string name;
    int age;
    string sex;
    string country;
    double flight_duration;//����ʱ��
    double Calmnessness;//�侲��
    double Professionssional;//רҵ��
    double execution;//ִ����
    double learning;//ѧϰ��
    double r_p;//��������
    double languages;//����ˮƽ
    double effect;//Ӱ����
    double morality;//����

    public PlaneCaptain()
    {

    }

    //
    public static PlaneCaptain GetPointsPlaneCaptain(float points, float investmentlevel, City c)
    {
        return null;
    }

    public static PlaneCaptain GetRandomPlaneCaptain(float investmentlevel, City c)
    {
        PlaneCaptain temp = new PlaneCaptain();
        List<string> countries = GlobalVariable.DefaultManager.countriesManager.countriesName;
        int random = Random.Range(0, countries.Count);
        temp.country = countries[random];//�����ٳ��������ɸ��ʷֲ���Ŀǰ��ʱ�þ��ȷֲ���
        temp.name = "TestName";//��ʱ��δ������������������
        float random_f = Random.Range(0f, 1f);
        string sex;
        if (random_f <= 0.9)
        {
            sex = "male";
        }
        else sex = "female";
        temp.sex = sex;
        //Debug.Log("sex: " + sex);
        temp.age = Random.Range(PlaneCaptainParameter.minAge, PlaneCaptainParameter.maxAge);
        //Debug.Log("age: " + age);
        double random_d = PlaneCaptainParameter.FlightDurationrandom * Random.Range(0, 100);
        double flight_duration = (double)investmentlevel * PlaneCaptainParameter.FlightDurationlevel + (double)c.personnel * PlaneCaptainParameter.FlightDurationpersonnel + random_d;
        flight_duration *= 1000;
        temp.flight_duration = ((double)flight_duration) / 100;
        //Debug.Log("flight_duration: " + flight_duration);
        random_d = PlaneCaptainParameter.Calmnessrandom * Random.Range(0, 100);
        double Calmnessness = (int)investmentlevel * PlaneCaptainParameter.Calmnesslevel + (double)c.personnel * PlaneCaptainParameter.Calmnesspersonnel + random_d;
        temp.Calmnessness = (double)(int)Calmnessness;
        //Debug.Log("Calmnessness: " + Calmnessness);
        random_d = PlaneCaptainParameter.Professionrandom * Random.Range(0, 100);
        double Profession = (double)investmentlevel * PlaneCaptainParameter.Professionlevel + (double)c.personnel * PlaneCaptainParameter.Professionpersonnel + random_d;
        temp.Professionssional = (double)(int)Profession;
        //Debug.Log("Profession: " + Profession);
        random_d = PlaneCaptainParameter.Executionrandom * Random.Range(0, 100);
        double Execution = (double)investmentlevel * PlaneCaptainParameter.Executionlevel + (double)c.personnel * PlaneCaptainParameter.Executionpersonnel + random_d;
        temp.execution = (double)(int)Execution;
        //Debug.Log("Execution: " + Execution);
        random_d = PlaneCaptainParameter.Learningrandom * Random.Range(0, 100);
        double Learning = (double)investmentlevel * PlaneCaptainParameter.Learninglevel + (double)c.personnel * PlaneCaptainParameter.Learningpersonnel + random_d;
        temp.learning = (double)(int)Learning;
        //Debug.Log("Learning: " + Learning);
        random_d = PlaneCaptainParameter.RnPrandom * Random.Range(0, 100);
        double RnP = (double)investmentlevel * PlaneCaptainParameter.RnPlevel + (double)c.personnel * PlaneCaptainParameter.RnPpersonnel + random_d;
        temp.r_p = (double)(int)RnP;
        //Debug.Log("RnP: " + RnP);
        random_d = PlaneCaptainParameter.Languagerandom * Random.Range(0, 100);
        double Language = (double)investmentlevel * PlaneCaptainParameter.Languagelevel + (double)c.personnel * PlaneCaptainParameter.Languagepersonnel + random_d;
        temp.languages = (double)(int)Language;
        //Debug.Log("Language: " + Language);
        random_d = PlaneCaptainParameter.Effectrandom * Random.Range(0, 100);
        double Effect = (double)investmentlevel * PlaneCaptainParameter.Effectlevel + (double)c.personnel * PlaneCaptainParameter.Effectpersonnel + random_d;
        temp.effect = (double)(int)Effect;
        //Debug.Log("Effect: " + Effect);
        random_d = PlaneCaptainParameter.Moralityrandom * Random.Range(0, 100);
        double Morality = (double)investmentlevel * PlaneCaptainParameter.Moralitylevel + (double)c.personnel * PlaneCaptainParameter.Moralitypersonnel + random_d;
        temp.morality = (double)(int)Morality;
        //Debug.Log("Morality: " + Morality);
        return null;
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
    //ѧϰ��������������ͬ��
    //Learning
    public static double Learninglevel = 10;
    public static double Learningpersonnel = 0.1;
    public static double Learningrandom = 0.5;
    //�������ʣ�tΪÿ��˥��ֵ��minΪ����ֵ����Сֵ
    //RnP
    public static double RnPlevel = 10;
    public static double RnPpersonnel = 0.1;
    public static double RnPrandom = 0.2;
    public static double RnPt = 1;
    public static double RnPmin = 30;
    //�������������صĸ������
    //������������������ͬרҵ��
    //Language
    public static double Languagelevel = 10;
    public static double Languagepersonnel = 0.1;
    public static double Languagerandom = 0.2;
    public static double Languageinvestment = 0.0002;
    public static double Languagemaxgrow = 30;
    //Ӱ������probΪÿ�������ӵĸ��ʣ�rangeΪ����ֵ�ķ�Χ
    //Effect
    public static double Effectlevel = 10;
    public static double Effectpersonnel = 0.1;
    public static double Effectrandom = 0.2;
    public static double Effectprob = 0.2;
    public static double Effectrange = 5;
    public static double Effectmaxgrow = 30;
    //����ֵ����������ͬѧϰ����
    //Morality
    public static double Moralitylevel = 20;
    public static double Moralitypersonnel = 0.05;
    public static double Moralityrandom = 0.3;
}