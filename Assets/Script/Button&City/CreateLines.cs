using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CreateLines : MonoBehaviour
{
    // Start is called before the first frame update
    public TempVariable Temp;
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
        GlobalVariable.ChooseCity = GlobalChooseCityState.CREATELINE;
        Debug.Log(tCity.name);
        Temp.tempLine = new Line(GlobalVariable.DefaultManager.lines_manager.id);
        Temp.tempLine.SetPoints(0, tCity);
        selectCity.SetActive(false);
        board.SetActive(false);
    }
}
