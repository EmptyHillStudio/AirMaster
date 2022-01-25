using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CreateLines : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject selectCity;
    public GameObject board;
    public GameObject cityname;
    private static CitiesManager cManager;
    private string CityName;
    private City tCity;

    public void OnClick()
    {
        cManager = GlobalVariable.DefaultManager.cities_manager;
        string CityName = cityname.GetComponent<Text>().text;
        tCity = cManager.getCityByName(CityName);
        tCity.SetBegin(tCity);
        selectCity.SetActive(false);
        board.SetActive(false);
    }
}
