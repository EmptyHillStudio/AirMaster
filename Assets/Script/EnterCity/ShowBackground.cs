using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowBackground : MonoBehaviour
{
    private City tCity;
    private static CitiesManager cManager;
    public Text Cityname;
    public GameObject back;
    private Sprite sprite1, sprite2, sprite3,sprite4,sprite5;
    public Texture2D texture1, texture2, texture3, texture4, texture5;
    void Start()
    {
        cManager = GlobalVariable.DefaultManager.cities_manager;
        //string Name = Cityname.text;
        tCity = cManager.getCityByName(GlobalVariable.CityName);
        string scale = tCity.getScale();
        sprite1 = Sprite.Create(texture1, new Rect(0, 0, texture1.width, texture1.height), new Vector2(0.5f, 0.5f));
        sprite2 = Sprite.Create(texture2, new Rect(0, 0, texture2.width, texture2.height), new Vector2(0.5f, 0.5f));
        sprite3 = Sprite.Create(texture3, new Rect(0, 0, texture3.width, texture3.height), new Vector2(0.5f, 0.5f));
        sprite4 = Sprite.Create(texture4, new Rect(0, 0, texture4.width, texture4.height), new Vector2(0.5f, 0.5f));
        sprite5 = Sprite.Create(texture5, new Rect(0, 0, texture5.width, texture5.height), new Vector2(0.5f, 0.5f));
        if(scale ==City_Scale.TINY.ToString())
            back.GetComponent<Image>().sprite = sprite1;
        else if (scale == City_Scale.SMALL.ToString())
            back.GetComponent<Image>().sprite = sprite2;
        else if (scale == City_Scale.MIDDLE.ToString())
            back.GetComponent<Image>().sprite = sprite3;
        else if (scale == City_Scale.LARGE.ToString())
            back.GetComponent<Image>().sprite = sprite4;
        else if (scale == City_Scale.HUGE.ToString())
            back.GetComponent<Image>().sprite = sprite5;
    }
}
