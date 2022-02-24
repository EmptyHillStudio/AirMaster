using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EventHandleTest : MonoBehaviour
{
    // 定义事件名称
    public const string ON_CLICK = "Epidemic";
    public static List<string[]> Datas;
    public static  List<string> GetEventTypeName()
    {
        List<string> eventTypeName = new List<string>();
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Events.csv");
        foreach (var line in Datas)
        {
            eventTypeName.Add(line[0]);
        }
        Debug.Log(eventTypeName[0]);
        return eventTypeName;
    }

    private void Start()
    {
        List<string> eventTypeName = new List<string>();
        Datas = new List<string[]>();
        loadFile(Application.dataPath + "/Res/Data", "Events.csv");
        foreach (var line in Datas)
        {
            eventTypeName.Add(line[0]);
        }
        // 添加监听器
        for (int i=0;i<eventTypeName.Count;i++)
        {
            if (!EventUtil.HasListener(eventTypeName[i]))
                EventUtil.AddListener(eventTypeName[i], OnClick);
        }
        
        
        
    }

    // 处理点击事件
    public void OnClick(EventArgs evt)
    {
        Debug.Log("111111111");
    }

    
    // 移除监听器
    private void OnDestroy()
    {
        EventUtil.RemoveListener(ON_CLICK, OnClick);
        //EventUtil.RemoveListener(ON_CLICK2, OnClick2);
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
