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
    public GameObject selectboard;
    
    public void OnPointerClick(PointerEventData eventData)
    {

        int radius = 3;
        Collider[] cols = Physics.OverlapSphere(this.transform.position, radius, LayerMask.NameToLayer("layername"));
        if (cols.Length > 0)
        {
            
            GameObject citybutton = GameObject.Find("CityButton");
            for (int i = 0; i < cols.Length; i++)
            {
                Vector3 v = new Vector3(0, 80-i*35, 0);
                GameObject cb = GameObject.Instantiate(citybutton, v, Quaternion.identity) as GameObject;
                cb.transform.GetComponent<Text>().text=cols[i].name;
               
                
            }
            selectboard.SetActive(true);
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



