using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCityInfo : MonoBehaviour
{
    public GameObject CityName;
    public Text Economy_index;
    public Text Toursm_index;
    public Text Population_index;
    private static CitiesManager cManager;
    private City tCity;
    // Start is called before the first frame update
    void Start()
    {
        CityName.GetComponent<Text>().text = GlobalVariable.CityName;
        cManager = GlobalVariable.DefaultManager.cities_manager;
        
        tCity = cManager.getCityByName(GlobalVariable.CityName);
        Economy_index.GetComponent<Text>().text = tCity.economy.ToString();
        Toursm_index.GetComponent<Text>().text = tCity.tourism.ToString();
        Population_index.GetComponent<Text>().text = tCity.getName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
