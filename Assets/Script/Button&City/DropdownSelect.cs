using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dropdown;
    public CityBindToBoard InfomationBoard;
    private static CitiesManager cManager;
    private string CityName;
    private City tCity;
    private static LinesManager lManager;
    public GameObject confirmcreate;
    public GameObject operationcom;
    public GameObject cityinfo;
    // Update is called once per frame
    public void OnChangeValue()
    {
        if (dropdown.GetComponent<Dropdown>().options[dropdown.GetComponent<Dropdown>().value].text != "SelectCity")
        {
            cManager = GlobalVariable.DefaultManager.cities_manager;
            string CityName = dropdown.GetComponent<Dropdown>().options[dropdown.GetComponent<Dropdown>().value].text;
            tCity = cManager.getCityByName(CityName);
            if (cManager.getBeginCity() != null)
            {
                if (cManager.getBeginCity().name.Equals(CityName))
                {
                    Debug.Log("«Î—°‘Ò÷’µ„");
                }
                else
                {
                    InfomationBoard.UpdateContent(tCity);
                    cityinfo.SetActive(true);
                    confirmcreate.SetActive(true);
                    operationcom.SetActive(false);
                }
            }
            else
            {
                confirmcreate.SetActive(false );
                operationcom.SetActive(true );
                InfomationBoard.UpdateContent(tCity);
            }

        }

    }
}
