using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityBindToBoard : MonoBehaviour
{
    private City bindCity;
    public Text CityName;
    private Image[] Thumbnail;
    public GameObject Board;
    public void setCity(City city)
    {
        this.bindCity = city;
    }
    public void UpdateContent(City city)
    {
        CityName.GetComponent<Text>().text = city.getName();
        setCity(city);
        Board.SetActive(true);
    }
}
