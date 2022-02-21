using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterCityButton : MonoBehaviour
{
    public Text cityname;
   
    public void OnClick()
    {
        SceneManager.LoadScene("City");
        GlobalVariable.CityName = cityname.text;
        
    }
}
