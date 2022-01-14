using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//该类集合定义了多个需要用到的基础变量，可以直接使用

public class GlobalVariable
{
    //全局时间戳，每帧会使时间戳加一
    public static Timer gTimer;

    //全局初始日期定义和相应的控制属性
    public static Date GameDate;
    public static bool IsPaused = true;
    public static int SpeedTime = 1;
}
