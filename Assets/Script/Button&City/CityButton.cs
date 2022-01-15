using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CityButton : MonoBehaviour
{
    // Start is called beforeCitiesManager c = new City();

    private static CitiesManager cManager;
    
    
   // Update is called once per frame
    
    public void Click()
    {
        cManager = new CitiesManager();
        
        string name = this.name;
        string city_intro =cManager.getCityByName(name).getIntroduction();
        GameObject city_intro_obj = GameObject.Find("city_introduction");
        Text city_intro_text = city_intro_obj.GetComponent<Text>();
        city_intro_text.text = city_intro;
        Debug.Log(city_intro_text.text);


    }


}



