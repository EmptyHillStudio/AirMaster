using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using Trigger;



public class DateEvents
{
    public static List<string> YearMethods;
    public static List<string> MonthMethods;
    public static List<string> DayMethods;
    public static Dictionary<string, string> AccurateMethods;
    public DateEvents()
    {
        YearMethods = new List<string>();
        MonthMethods = new List<string>();
        DayMethods = new List<string>();
        AccurateMethods = new Dictionary<string, string>();
        Type t = typeof(CustomEvent);
        MethodInfo[] mi = t.GetMethods();
        foreach (MethodInfo m in mi)
        {//判断Event.cs下所有的方法，并查询其触发方式，根据触发方式分类
            TriggerModeAttribute triggerMode = (TriggerModeAttribute)m.GetCustomAttribute(typeof(TriggerModeAttribute));
            if (triggerMode == null)
            {
                continue;
            }
            switch (triggerMode.Mode)
            {
                case TriggerMode.DATE:
                    string n = m.Name;
                    switch (triggerMode.pars[0])
                    {
                        case "day":
                            DayMethods.Add(n);
                            break;
                        case "month":
                            MonthMethods.Add(n);
                            break;
                        case "year":
                            YearMethods.Add(n);
                            break;
                        case "accurate":
                            AccurateMethods.Add(n, triggerMode.pars[1]);
                            break;
                    }
                    break;
            }
        }
    }
}
