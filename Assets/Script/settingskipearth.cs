using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class settingskipearth : MonoBehaviour
{
    public Slider m_slider;
    public Text text;
    public void Click()
    {
        SceneManager.LoadScene("earth");
        GlobalVariable.GameDate = new Date(Convert.ToInt32(m_slider.value), 1, 1);
        GlobalVariable.CompanyName = text.text;
    }
}
