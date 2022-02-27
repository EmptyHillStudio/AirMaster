using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;


public class DataLoader
{
    private static int re = 160;    //ģ�Ͱ뾶��160
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
        foreach (var line in Datas)//���ж�ȡ��ÿһ����һ�����еĸ�������
        {
            int id = System.Convert.ToInt32(line[0]);//id
            float latitude = System.Convert.ToSingle(line[3]); //γ��
            float longitude = System.Convert.ToSingle(line[4]); //����
            float economy = System.Convert.ToSingle(line[7]); //����ָ��
            float tourism = System.Convert.ToSingle(line[8]); //����ָ��
            //��ת������㣨��ֱ�ڷ������ĽǶȷ�����
            float ry = longitude - 90;
            float rx = latitude;
            float rz = 0;
            latitude = latitude / 180 * System.Convert.ToSingle(3.14159265); //ת���ɻ���
            longitude = longitude / 180 * System.Convert.ToSingle(3.14159265); //ת���ɻ���
            City temp = new City(id, line[6], line[1], latitude, longitude, economy, tourism); 
            cManager.add(temp);
            //����������������ĵ�������
            double tx = re * Math.Cos(latitude) * Math.Cos(longitude),
            ty = re * Math.Sin(latitude),
            tz = re * Math.Cos(latitude) * Math.Sin(longitude);
            //������꣨����ھ�������ϵ��
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

    //��ʷ�ɻ���ȡ
    public static PlanesManager GetPlanesManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Planes.csv");
        PlanesManager planesManager = new PlanesManager();
        int planes_num = 0;
        foreach (var line in Datas)//���ж�ȡ��ÿһ����һ����˾�ĸ�������
        {
            planes_num++;
            Plane temp = new Plane(line[0], line[1], line[2], line[3], line[4], line[5], line[6], line[7], line[8], line[10], line[11], line[12], line[13]);
            planesManager.Add(temp);
        }
        Debug.Log(planes_num + " planes has been loaded!");
        return planesManager;
    }

    //��˾���ݶ�ȡ
    public static CompaniesManager GetCompaniesManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Companies.csv");
        CompaniesManager companiesManager = new CompaniesManager();
        int companies_num = 0;
        foreach (var line in Datas)//���ж�ȡ
        {
            companies_num++;
            Company temp = new Company(line[0], line[2], line[3], line[4], line[5]);
            companiesManager.Add(temp);
        }
        Debug.Log(companies_num + " companies has been loaded!");
        return companiesManager;
    }


    //��ȡ�������ݲ����ع���������
    public static CountriesManager GetCountriesManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Countries.csv");
        CountriesManager countriesManager = new CountriesManager();
        int countries_num = 0;
        foreach (var line in Datas)//���ж�ȡ��ÿһ����һ����˾�ĸ�������
        {
            //Debug.Log(line[2] + "\t" + line[4]);
            Country temp = new Country(line[0], line[1], line[3], line[4]);
            countriesManager.Add(line[2], temp);
            countries_num++;
        }
        Debug.Log(countries_num + " countries has been loaded!");
        return countriesManager;
    }

    //��ȡ���������ع���������
    public static AirportsManager GetAirportsManager()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Airports.csv");
        AirportsManager airportsManager = new AirportsManager();
        int airports_num = 0;
        foreach (var line in Datas)//���ж�ȡ��ÿһ����һ����˾�ĸ�������
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
