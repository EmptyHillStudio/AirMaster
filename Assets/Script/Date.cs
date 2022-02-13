using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date
{
    private int[] standerd_month_leap = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    private int[] standerd_month = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public string[] monthname = { "Jen", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
    private bool Leap = false; public bool isLeap() { return this.Leap; }
    private int year, month, day;
    private bool Lack;public bool isLack() { return this.Lack; }//缺省日期
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
    public Date(int year,int month)//没有具体时间的日期
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

    public static Date FormatDate(string Standered)
    {
        string[] ymd = Standered.Split('/');
        List<int> ymdInt = new List<int>();
        foreach(string s in ymd)
        {
            ymdInt.Add(Convert.ToInt32(s));
        }
        Date temp = new Date(ymdInt[2], ymdInt[0], ymdInt[1]);
        return temp;
    }

    public static bool InRange(Date reg, Date end, Date now)
    {
        if (reg.getYear()<now.getYear()&&end.getYear()>now.getYear())
        {
            return true;
        }else if (reg.getYear() == now.getYear() && end.getYear() == now.getYear())
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
        daycheck();
    }
    private void daycheck()
    {
        if (Leap)
        {
            if (day > standerd_month_leap[month - 1])
            {
                month++;
                day = 1;
                if (month > 12)
                {
                    year++;
                    month = 1;
                    Leap = false;
                }
            }
        }
        else
        {
            if (day > standerd_month[month - 1])
            {
                month++;
                day = 1;
                if (month > 12)
                {
                    year++;
                    month = 1;
                    if (year % 4 == 0)
                    {
                        Leap = true;
                    }
                }
            }
        }
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
