using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;


public class DataLoader : MonoBehaviour
{
    private int re = 160;    //ģ�Ͱ뾶��160
    public List<string[]> Cities_Data;
    public CitiesManager cManager;
    // Start is called before the first frame update
    void Start()
    {
        this.Cities_Data = new List<string[]>();
        loadFile(Application.dataPath+"/Res", "World_Cities_Location_table.csv");
        cManager = new CitiesManager();
        GameObject db3 = GameObject.Find("3DButton");
        Vector3 db3_Position = db3.transform.position;
        var buttonParent = GameObject.Find("Buttons");
        foreach (var line in Cities_Data)//���ж�ȡ��ÿһ����һ�����еĸ�������
        {
            float latitude = System.Convert.ToSingle(line[3]); //γ��
            float longitude = System.Convert.ToSingle(line[4]); //����
            //��ת������㣨��ֱ�ڷ������ĽǶȷ�����
            float ry = longitude - 90;
            float rx = latitude;
            float rz = 0;
            latitude = latitude / 180 * System.Convert.ToSingle(3.14159265); //ת���ɻ���
            longitude = longitude / 180 * System.Convert.ToSingle(3.14159265); //ת���ɻ���
            City temp = new City(line[6], latitude, longitude); 
            Debug.Log(line[2]);
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadFile(string path,string fileName)
    {
        this.Cities_Data.Clear();
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "//" + fileName);
            Debug.Log("file is finded!");
        }
        catch
        {
            Debug.Log("file don't exist!");
        }
        string line;
        while ((line=sr.ReadLine())!=null)
        {
            Cities_Data.Add(line.Split(','));
        }
        sr.Close();
        sr.Dispose();
    }

}
