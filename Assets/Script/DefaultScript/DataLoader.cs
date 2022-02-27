using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;


public class DataLoader
{
    private static int re = 160;    //模型半径：160
    public static List<string[]> Datas;
    private static CitiesManager cManager;
    // Start is called before the first frame update
    public static CitiesManager getManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath+"/Res/Data", "Cities.csv");
        cManager = new CitiesManager();
        GameObject db3 = GameObject.Find("3DButton");
        Vector3 db3_Position = db3.transform.position;
        var buttonParent = GameObject.Find("Buttons");
        int ci_num = 0;
        foreach (var line in Datas)//按行读取，每一行是一个城市的各项数据
        {
            int id = System.Convert.ToInt32(line[0]);//id
            float latitude = System.Convert.ToSingle(line[3]); //纬度
            float longitude = System.Convert.ToSingle(line[4]); //经度
            float economy = System.Convert.ToSingle(line[7]); //经济指数
            float tourism = System.Convert.ToSingle(line[8]); //旅游指数
            //旋转坐标计算（垂直于法向量的角度分量）
            float ry = longitude - 90;
            float rx = latitude;
            float rz = 0;
            latitude = latitude / 180 * System.Convert.ToSingle(3.14159265); //转换成弧度
            longitude = longitude / 180 * System.Convert.ToSingle(3.14159265); //转换成弧度
            City temp = new City(id, line[6], line[1], latitude, longitude, economy, tourism); 
            cManager.add(temp);
            //法向量（相对于球心的向量）
            double tx = re * Math.Cos(latitude) * Math.Cos(longitude),
            ty = re * Math.Sin(latitude),
            tz = re * Math.Cos(latitude) * Math.Sin(longitude);
            //相对坐标（相对于绝对坐标系）
            float x = db3_Position[0] - System.Convert.ToSingle(tx),
                y = db3_Position[1] - System.Convert.ToSingle(ty),
                z = db3_Position[2] + System.Convert.ToSingle(tz);
            Vector3 v = new Vector3(x, y, z);
            GameObject go = GameObject.Instantiate(db3, v, Quaternion.identity) as GameObject;
            go.transform.localEulerAngles = new Vector3(rx, ry, rz);
            go.name = line[6];
            ci_num++;
        }
        Debug.Log(ci_num + " cities has been loaded!");
        return cManager;
    }

    //历史飞机读取
    public static PlanesManager GetPlanesManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Planes.csv");
        PlanesManager planesManager = new PlanesManager();
        int planes_num = 0;
        foreach (var line in Datas)//按行读取，每一行是一个公司的各项数据
        {
            planes_num++;
            Plane temp = new Plane(line[0], line[1], line[2], line[3], line[4], line[5], line[6], line[7], line[8], line[10], line[11], line[12], line[13]);
            planesManager.Add(temp);
        }
        Debug.Log(planes_num + " planes has been loaded!");
        return planesManager;
    }

    //公司数据读取
    public static CompaniesManager GetCompaniesManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Companies.csv");
        CompaniesManager companiesManager = new CompaniesManager();
        int companies_num = 0;
        foreach (var line in Datas)//按行读取
        {
            companies_num++;
            Company temp = new Company(line[0], line[2], line[3], line[4], line[5]);
            companiesManager.Add(temp);
        }
        Debug.Log(companies_num + " companies has been loaded!");
        return companiesManager;
    }


    //获取国家数据并返回管理器对象
    public static CountriesManager GetCountriesManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Countries.csv");
        CountriesManager countriesManager = new CountriesManager();
        int countries_num = 0;
        foreach (var line in Datas)//按行读取，每一行是一个公司的各项数据
        {
            //Debug.Log(line[2] + "\t" + line[4]);
            Country temp = new Country(line[0], line[1], line[3], line[4]);
            countriesManager.Add(line[2], temp);
            countries_num++;
        }
        Debug.Log(countries_num + " countries has been loaded!");
        return countriesManager;
    }

    //获取机场并返回管理器对象
    public static AirportsManager GetAirportsManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Airports.csv");
        AirportsManager airportsManager = new AirportsManager();
        int airports_num = 0;
        foreach (var line in Datas)//按行读取，每一行是一个公司的各项数据
        {
            Debug.Log(line[1]);
            Airport temp = new Airport(line[0], line[1], line[2], line[3], line[4], line[5], line[6]);
            airportsManager.Add(Convert.ToInt32(line[0]), temp);
            airports_num++;
        }
        Debug.Log(airports_num + " airports has been loaded!");
        return airportsManager;
    }

    public static void loadFile(string path,string fileName)
    {
        Datas.Clear();
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "/" + fileName);
            Debug.Log("file " + path + "/" + fileName + " is finded!");
        }
        catch
        {
            Debug.Log("file don't exist!");
        }
        string line;
        while ((line=sr.ReadLine())!=null)
        {
            Datas.Add(line.Split(','));
        }
        sr.Close();
        sr.Dispose();
    }

}
