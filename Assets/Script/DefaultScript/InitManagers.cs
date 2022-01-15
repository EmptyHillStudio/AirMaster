using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour
{
    //可以从该管理器对象中获取已读取的数据，但每个数据对象需要在各自的类文件中声明。
    public  CitiesManager cities_manager;
    public   LinesManager lines_manager;
    public  DateManager date_manager;
    void Start()
    {
        this.cities_manager = DataLoader.getManager();
        this.lines_manager = new LinesManager();
        if(GlobalVariable.GameDate == null)
        {
            GlobalVariable.GameDate = new Date(1960, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
