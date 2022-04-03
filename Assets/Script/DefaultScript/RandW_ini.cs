using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

public class RandW_ini 
{
    public string path;//ini文件路径
    public RandW_ini(string path)
    {
        this.path = path;
    }
    [DllImport("kernel32")]
    public static extern long WritePrivateProfileString(string section, string key, string values, string path);
    [DllImport("kernel32")]
    public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string path);
    
    public void WriteIniContent(string section,string key,string values)
    {
        WritePrivateProfileString(section, key, values, path);
    }
    public string ReadInitContent(string section,string key)
    {
        StringBuilder temp = new StringBuilder(255);
        int i = GetPrivateProfileString(section, key, "", temp, 255, path);
        return temp.ToString();
        
    }
    //判断路径是否正确
    public bool IsIniPath()
    {
        return File.Exists(this.path);
    }
}
