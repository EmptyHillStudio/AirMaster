using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class settingskipearth : MonoBehaviour
{
    public Slider m_slider;
    // Start is called before the first frame update

    public void Click()
    {
        SceneManager.LoadScene("earth");
        GlobalVariable.GameDate = new Date(Convert.ToInt32(m_slider.value), 1, 1);
    }
}
