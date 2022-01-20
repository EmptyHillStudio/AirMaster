using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCityButton : MonoBehaviour
{
    // Start is called before the first frame update

    
    public CityBindToBoard InfomationBoard;
    private static CitiesManager cManager;
    private string CityName;
    private City tCity;
    // Update is called once per frame
    public void Click()
    {
        Text text = this.transform.GetComponent<Text>();
        cManager = GlobalVariable.DefaultManager.cities_manager;
        string CityName = text.text;
        tCity = cManager.getCityByName(CityName);
        InfomationBoard.UpdateContent(tCity);
    }
}
