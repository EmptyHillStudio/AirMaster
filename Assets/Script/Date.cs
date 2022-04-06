using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date
{
    private int[] standerd_month_leap = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    private int[] standerd_month = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public string[] monthname = { "Jen", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
    private bool Leap = false; public bool isLeap() { return this.Leap; }
    public int year, month, day;
    private bool Lack; public bool isLack() { return this.Lack; }//缺省日期

    public Date(int year, int month, int day)
    {
        setDay(day);
        setMonth(month);
        setYear(year);
        if (year % 4 == 0)
        {
            this.Leap = true;
        }
        this.Lack = false;
    }
    public Date(int year, int month)//没有具体时间的日期
    {
        setYear(year);
        setMonth(month);
        if (year % 4 == 0)
        {
            this.Leap = true;
        }
        this.Lack = true;
    }

    public Date(string year)
    {
        int temp = Convert.ToInt32(year);
        setYear(temp);
        setMonth(1);
        setDay(1);
        if (temp % 4 == 0)
        {
            this.Leap = true;
        }
    }

    public static Date FormatDate(string Standered)//标准化日期，月/日/年
    {
        string[] ymd = Standered.Split('/');
        List<int> ymdInt = new List<int>();
        foreach (string s in ymd)
        {
            ymdInt.Add(Convert.ToInt32(s));
        }
        Date temp = new Date(ymdInt[2], ymdInt[0], ymdInt[1]);
        return temp;
    }

    public static bool InRange(Date reg, Date end, Date now)
    {
        if (reg.getYear() < now.getYear() && end.getYear() > now.getYear())
        {
            return true;
        }
        else if (reg.getYear() == now.getYear() && end.getYear() == now.getYear())
        {
            if (reg.getMonth() < now.getMonth() && end.getMonth() > now.getMonth())
            {
                return true;
            }
            else if (reg.getMonth() == now.getMonth() && end.getMonth() == now.getMonth())
            {
                if (reg.getDay() <= now.getDay() && end.getDay() >= now.getDay())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }
    public static int TimeDifference(Date start, Date now)//计算现在与起始时间的时间差
    {
        int Differ = 0;
        if (start.getYear() < now.getYear())//如果跨年
        {
            if (start.Leap == false)
            {
                Differ = Differ + start.standerd_month[start.getMonth() - 1] - start.getDay();
                for (int i = start.getMonth() + 1; i <= 12; i++)
                    Differ = Differ + now.standerd_month[i - 1];
            }
            else
            {
                Differ = Differ + start.standerd_month_leap[start.getMonth() - 1] - start.getDay();
                for (int i = start.getMonth() + 1; i <= 12; i++)
                    Differ = Differ + now.standerd_month_leap[i - 1];
            }
            start.year = now.year;
            start.month = 1;
            start.day = 1;
        }
        if (now.Leap == false)//同年计算
        {
            if (start.month < now.month)
                Differ = Differ + start.standerd_month[start.getMonth() - 1] - start.getDay();
            for (int i = start.getMonth() + 1; i < now.getMonth(); i++)
                Differ = Differ + now.standerd_month[i - 1];
            Differ = Differ + now.getDay();
        }
        else
        {
            if (start.month < now.month)
                Differ = Differ + start.standerd_month_leap[start.getMonth() - 1] - start.getDay();
            for (int i = start.getMonth() + 1; i < now.getMonth(); i++)
                Differ = Differ + now.standerd_month_leap[i - 1];
            Differ = Differ + now.getDay();
        }
        return Differ;
    }
    public static Date GetPutOff(Date date, int year)
    {
        return new Date(date.getYear() + year, date.getMonth(), date.getDay());
    }

    public int getYear()
    {
        return year;
    }
    public int getMonth()
    {
        return month;
    }
    public int getDay()
    {
        return day;
    }
    public void setYear(int year)
    {
        this.year = year;
    }
    public void setMonth(int month)
    {
        this.month = month;
    }
    public void setDay(int day)
    {
        this.day = day;
    }
    public void dayPlus()
    {//当前天数加一，检查当前天数
        this.day++;
        //Debug.Log(DateEvents.DayMethods[0]);
        for (int i = 0; i < DateEvents.DayMethods.Count; i++)
        {
            CustomEvent ev = new CustomEvent();
            Type t = typeof(CustomEvent);
            MethodInfo mi = t.GetMethod(DateEvents.DayMethods[i]);
            //Debug.Log(DateEvents.DayMethods[i]);
            mi.Invoke(ev, null);
        }
        foreach (KeyValuePair<string, string> s in DateEvents.AccurateMethods)
        {
            CustomEvent ev = new CustomEvent();
            Type t = typeof(CustomEvent);
            Date temp = FormatDate(s.Value);
            if (GlobalVariable.GameDate.year == temp.year &&
                GlobalVariable.GameDate.month == temp.month &&
                GlobalVariable.GameDate.day == temp.day)  //当前时间早于事件时间则不再检测该事件
            {
                continue;
            }
            MethodInfo mi = t.GetMethod(s.Key);
            //Debug.Log(DateEvents.DayMethods[i]);
            mi.Invoke(ev, null);
        }
        daycheck();
    }
    private void daycheck()
    {
        if (Leap)
        {
            if (day > standerd_month_leap[month - 1])
            {
                monthPlus();
                day = 1;
                if (month > 12)
                {
                    yearPlus();
                    month = 1;
                    Leap = false;
                }
            }
        }
        else
        {
            if (day > standerd_month[month - 1])
            {
                monthPlus();
                day = 1;
                if (month > 12)
                {
                    yearPlus();
                    month = 1;
                    if (year % 4 == 0)
                    {
                        Leap = true;
                    }
                }
            }
        }
    }

    private void monthPlus()
    {
        for (int i = 0; i < DateEvents.MonthMethods.Count; i++)
        {
            month++;
            CustomEvent ev = new CustomEvent();
            Type t = typeof(CustomEvent);
            MethodInfo mi = t.GetMethod(DateEvents.MonthMethods[i]);
            mi.Invoke(ev, null);
        }
    }

    private void yearPlus()
    {
        year++;
        for (int i = 0; i < DateEvents.YearMethods.Count; i++)
        {
            CustomEvent ev = new CustomEvent();
            Type t = typeof(CustomEvent);
            MethodInfo mi = t.GetMethod(DateEvents.YearMethods[i]);
            mi.Invoke(ev, null);
        }
    }

    public static bool operator <(Date d1, Date d2)
    {
        if (d1.year < d2.year)
        {
            return true;
        }
        else if (d1.year == d2.year)
        {
            if (d1.month < d2.month) return true;
            if (d1.month == d2.month)
            {
                if (d1.day < d2.day) { return true; }
                else return false;
            }
            else return false;
        }
        else return false;
    }
    public static bool operator >(Date d1, Date d2)
    {
        if (d1.year > d2.year)
        {
            return true;
        }
        else if (d1.year == d2.year)
        {
            if (d1.month > d2.month) return true;
            if (d1.month == d2.month)
            {
                if (d1.day > d2.day) { return true; }
                else return false;
            }
            else return false;
        }
        else return false;
    }
    public override string ToString()
    {
        string dd = day.ToString();
        if (day < 10)
        {
            dd = dd.PadLeft(2, '0');
        }
        string re = dd + "\t\t" + monthname[month - 1] + "\t\t" + year;
        return re;
    }
}
