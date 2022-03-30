using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmCreate : MonoBehaviour
{
    // Start is called before the first frame update

    private static CitiesManager cManager;
    private string CityName;
    private City tCity;
    private static LinesManager lManager;
    public GameObject cityname;
    public GameObject cityinfo;
    // Update is called once per frame
    public void OnClick()
    {
        cManager = GlobalVariable.DefaultManager.cities_manager;
        CityName = cityname.GetComponent<Text>().text;
        tCity = cManager.getCityByName(CityName);
        lManager = GlobalVariable.DefaultManager.lines_manager;
        Debug.Log("Ìí¼Ó³É¹¦");
        cityinfo.SetActive(false);
    }
}
