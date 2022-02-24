using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EventTypeName
{
    List<string> eventTypeName = new List<string>();
    public static List<string[]> Datas;
    public  List<string> GetEventTypeName()
    {
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Events.csv");
        foreach (var line in Datas)
        {
            eventTypeName.Add(line[0]);
        }
        Debug.Log(eventTypeName[0]);
        return eventTypeName;
    }
    public static void loadFile(string path, string fileName)
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
        while ((line = sr.ReadLine()) != null)
        {
            Datas.Add(line.Split(','));
        }
        sr.Close();
        sr.Dispose();
    }
}
