using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour
{
    //可以从该管理器对象中获取已读取的数据，但每个数据对象需要在各自的类文件中声明。
    public CitiesManager cities_manager;//城市对象管理器
    public LinesManager lines_manager;//航线管理器
    public DateManager date_manager;//日期管理器
    public ThumbnailImageManager thumbnailImageManager;//规模图像管理器
    public AirportsManager airportsManager;
    public CountriesManager countriesManager;
    public CompaniesManager companiesManager;
    public PlanesManager planesManager;
    public ResearchManager researchesManager;
    void Start()
    {
        GlobalVariable.DefaultManager = this;
        //读取数据的顺序一定不能乱，否则会报NullPointerException
        //1先读取国家数据，保证城市数据获取国家时能够得到国家对象
        this.countriesManager = DataLoader.GetCountriesManager();
        //2读取城市数据
        this.cities_manager = DataLoader.getManager();
        //3读取各种公司的数据，初始化航线管理器
        this.companiesManager = DataLoader.GetCompaniesManager();
        this.lines_manager = new LinesManager();
        //4读取所有历史客机的数据
        this.planesManager = DataLoader.GetPlanesManager();
        //5读取所有机场的数据
        this.airportsManager = DataLoader.GetAirportsManager();
        //6读取科技和研究数据
        this.researchesManager = DataLoader.GetResearchesManager();
        //7读取航线需求数据

        //8
        if (GlobalVariable.GameDate == null)
        {
            GlobalVariable.GameDate = new Date(1970, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
