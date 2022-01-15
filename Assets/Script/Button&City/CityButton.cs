using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CityButton : MonoBehaviour , IPointerClickHandler
{
    public CityBindToBoard InfomationBoard;
    private static CitiesManager cManager;
    private string CityName;
    private City tCity;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        cManager = GlobalVariable.DefaultManager.cities_manager;
        string CityName = this.name;
        tCity = cManager.getCityByName(CityName);
        InfomationBoard.UpdateContent(tCity);
    }


}



