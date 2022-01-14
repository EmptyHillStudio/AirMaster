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
    public Date(int year, int month, int day)
    {
        setDay(day);
        setMonth(month);
        setYear(year);
        if (year % 4 == 0)
        {
            this.Leap = true;
        }
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
