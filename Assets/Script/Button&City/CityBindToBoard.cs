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
    public Text Talents_index;
    public GameObject Board;
    public GameObject Thumbnail;
    public Sprite sprite1, sprite2, sprite3, sprite4, sprite5;
    void Start()
    {
        /*/there are something needed to change:
        sprite1 = Sprite.Create(texture1, new Rect(0, 0, texture1.width, texture1.height), new Vector2(0.5f, 0.5f));
        sprite2 = Sprite.Create(texture2, new Rect(0, 0, texture2.width, texture2.height), new Vector2(0.5f, 0.5f));
        sprite3 = Sprite.Create(texture3, new Rect(0, 0, texture3.width, texture3.height), new Vector2(0.5f, 0.5f));
        sprite4 = Sprite.Create(texture4, new Rect(0, 0, texture4.width, texture4.height), new Vector2(0.5f, 0.5f));
        sprite5 = Sprite.Create(texture5, new Rect(0, 0, texture5.width, texture5.height), new Vector2(0.5f, 0.5f));
        */
    }
    public void setCity(City city)
    {
        this.bindCity = city;
    }
    public void UpdateContent(City city)
    {
        if(city != null)
        {
            Thumbnail.GetComponent<Image>().sprite = city.ScaleImage;
            CityName.GetComponent<Text>().text = city.getName();
            Economy_index.GetComponent<Text>().text = city.economy.ToString();
            Toursm_index.GetComponent<Text>().text = city.tourism.ToString();
            Talents_index.GetComponent<Text>().text = city.personnel.ToString();
            setCity(city);
            Board.SetActive(true);
        }
        else
        {
            Board.SetActive(false);
        }
    }
}
