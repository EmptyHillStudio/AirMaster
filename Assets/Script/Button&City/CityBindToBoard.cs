using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CityBindToBoard : MonoBehaviour
{
    private City bindCity;
    public Text CityName;
    public Text Economy_index;
    public Text Toursm_index;
    public Text Population_index;
    private Image[] Thumbnail;
    public GameObject Board;

    public void setCity(City city)
    {
        this.bindCity = city;
    }
    public void UpdateContent(City city)
    {
        CityName.GetComponent<Text>().text = city.getName();
        Economy_index.GetComponent<Text>().text = city.economy.ToString();
        Toursm_index.GetComponent<Text>().text = city.tourism.ToString();
        Population_index.GetComponent<Text>().text = city.getName();
        setCity(city);
        Board.SetActive(true);
    }
}
