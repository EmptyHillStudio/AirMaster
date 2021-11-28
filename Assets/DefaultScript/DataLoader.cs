using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public List<string[]> Cities_Data;
    // Start is called before the first frame update
    void Start()
    {
        this.Cities_Data = new List<string[]>();
        loadFile(Application.dataPath+"/Res", "World_Cities_Location_table.csv");
        CitiesManager cManager = new CitiesManager();
        foreach(var line in Cities_Data)
        {
            City temp = new City(line[2],System.Convert.ToDouble(line[3]), System.Convert.ToDouble(line[4]));
            Debug.Log(line[2]);
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
