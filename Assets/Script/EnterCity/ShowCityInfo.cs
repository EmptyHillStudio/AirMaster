using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowCityInfo : MonoBehaviour
{
    public GameObject CityName;
    public Text Economy_index;
    public Text Toursm_index;
    public Text Talents_index;
    private static CitiesManager cManager;
    private City tCity;
    public static List<string[]> Datas;
    //public GameObject SelectAirport;
    // Start is called before the first frame update
    void Start()
    {
        CityName.GetComponent<Text>().text = GlobalVariable.CityName;
        cManager = GlobalVariable.DefaultManager.cities_manager;
        
        tCity = cManager.getCityByName(GlobalVariable.CityName);
        Economy_index.GetComponent<Text>().text = tCity.economy.ToString();
        Toursm_index.GetComponent<Text>().text = tCity.tourism.ToString();
        Talents_index.GetComponent<Text>().text = tCity.personnel.ToString();
        Datas = new List<string[]>();
        List<string> Airports = new List<string>();
        Airports.Add("�������");
        foreach (var line in Datas)
        {
            if (line[2].Equals(CityName.GetComponent<Text>().text))
            {
                Airports.Add(line[1]);

            }
        }
        //SelectAirport.GetComponent<Dropdown>().AddOptions(Airports);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
