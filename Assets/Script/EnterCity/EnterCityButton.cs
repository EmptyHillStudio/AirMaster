using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterCityButton : MonoBehaviour
{
    public Text cityname;
    public Camera c;
    public void OnClick()
    {
        SceneManager.LoadScene("City");
        GlobalVariable.CityName = cityname.text;
        GlobalVariable.fieldOfView = c.GetComponent<Camera>().fieldOfView;
        GlobalVariable.rx = c.GetComponent<Transform>().eulerAngles.x;
        GlobalVariable.ry = c.GetComponent<Transform>().eulerAngles.y;
        GlobalVariable.rz = c.GetComponent<Transform>().eulerAngles.z;
        GlobalVariable.px = c.GetComponent<Transform>().localPosition.x;
        GlobalVariable.py = c.GetComponent<Transform>().localPosition.y;
        GlobalVariable.pz = c.GetComponent<Transform>().localPosition.z;
    }
}
