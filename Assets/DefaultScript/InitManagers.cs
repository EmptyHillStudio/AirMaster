using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour
{
    //可以从该管理器对象中获取已读取的数据，但每个数据对象需要在各自的类文件中声明。
    private CitiesManager cities_manager;
    void Start()
    {
        this.cities_manager = DataLoader.getManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
