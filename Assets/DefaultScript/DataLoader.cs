using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    public List<string[]> Cities_Data;
    // Start is called before the first frame update
    void Start()
    {
        this.Cities_Data = new List<string[]>();
        loadFile(Application.dataPath+"/Res", "World_Cities_Location_table.csv");
        CitiesManager cManager = new CitiesManager();
        GameObject db3 = GameObject.Find("3DButton");
        Vector3 db3_Position = db3.transform.position;
        var buttonParent = GameObject.Find("Buttons");
        foreach (var line in Cities_Data)
        {
            float latitude = System.Convert.ToSingle(line[3]);
            float longitude = System.Convert.ToSingle(line[4]);
            latitude = latitude / 180 * System.Convert.ToSingle(3.14159265);
            longitude = longitude / 180 * System.Convert.ToSingle(3.14159265);
            City temp = new City(line[6], latitude, longitude);
            Debug.Log(line[2]);
            cManager.add(temp);
            //法向量
            double tx = 160 * Math.Cos(latitude) * Math.Cos(longitude),
            ty = 160 * Math.Sin(latitude),
            tz = 160 * Math.Cos(latitude) * Math.Sin(longitude);
            //相对坐标
            float x = db3_Position[0] - System.Convert.ToSingle(tx),
                y = db3_Position[1] - System.Convert.ToSingle(ty),
                z = db3_Position[2] + System.Convert.ToSingle(tz);
            //旋转坐标计算
            float ry = -System.Convert.ToSingle((Math.Atan2(tx, tz) * 180) / 3.14159265);
            float rx = System.Convert.ToSingle((Math.Atan2(ty, tz)));
            float rz = System.Convert.ToSingle((Math.Atan2(ty, tx) * 180) / 3.14159265);
            Vector3 v = new Vector3(x, y, z);
            GameObject go = GameObject.Instantiate(db3, v, Quaternion.identity) as GameObject;
            go.transform.localEulerAngles = new Vector3(rz, ry, rx);
            go.name = line[6];
            go.transform.parent = buttonParent.transform;
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
