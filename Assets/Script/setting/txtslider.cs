using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class txtslider : MonoBehaviour
{
    public Slider m_slider;
    public Text  m_text;
    // Start is called before the first frame update
   

    // Update is called once per frame
    public void Update()
    {
        m_text.text = Convert.ToInt32(m_slider.value).ToString();

    }
}
