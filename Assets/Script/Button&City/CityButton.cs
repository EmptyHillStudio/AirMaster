using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class CityButton : MonoBehaviour , IPointerClickHandler
{
    public CityBindToBoard InfomationBoard;
    private static CitiesManager cManager;
    private string CityName;
    private City tCity;
    public GameObject dropdown;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        dropdown.GetComponent<RectTransform>().position = Input.mousePosition;
        dropdown.GetComponent<Dropdown>().ClearOptions();
        int radius = 1;
        Collider[] cols = Physics.OverlapSphere(this.transform.position, radius, LayerMask.NameToLayer("layername"));
        List<string> cityList = new List<string>();
        if (cols.Length > 2)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (i % 2 == 0)
                {
                    cityList.Add(cols[i].name);
                    Debug.Log(cols[i].name);
                }
                
            }
            Debug.Log(cols.Length);
            dropdown.GetComponent<Dropdown>().AddOptions(cityList);
            dropdown.SetActive(true);
            for (int i = 0; i < cols.Length; i++)
            {
                if (i % 2 == 0)
                {
                    cityList.Remove(cols[i].name);
                    
                }

            }
            
        }
        else
        {
            cManager = GlobalVariable.DefaultManager.cities_manager;
            string CityName = this.name;
            tCity = cManager.getCityByName(CityName);
            InfomationBoard.UpdateContent(tCity);
        }
    }
    
    

}



