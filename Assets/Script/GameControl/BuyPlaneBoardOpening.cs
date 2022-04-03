using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuyPlaneBoardOpening : MonoBehaviour
{
    public BoardBindedInPlaneBuying bbpb;//指向购买的飞机，需在载入时动态赋值
    public Text CompanyName, PlaneName, Model, Price, Size, Age, Fuel, Mileage, Speed, Capacity, CabinG;
    public Image CompanyIcon, PlaneIcon;
    public GameObject InfoBoard;
    public void OnClick()
    {
        Plane p = bbpb.BindedPlane;
        CompanyName.text = p.creater.name;
        CompanyIcon.sprite = p.creater.icon;
        PlaneIcon.sprite = p.icon;
        PlaneName.text = p.series + "-" + p.sub;
        Model.text = p.model;
        Price.text = "Price: " + p.price;
        Size.text = "Size: " + p.Size.ToString();
        Age.text = "Age(Year): " + p.age;
        Fuel.text = "Fuel Consumption(index): " + p.consumption;
        Mileage.text = "Maximum Mileage(km): " + p.mileage;
        Speed.text = "Speed(km/h): " + p.speed;
        Capacity.text = "Passenger Capacity: " + p.capacity;
        CabinG.text = "Cabin Gradation: " + p.classes;
        InfoBoard.SetActive(true);
    }
}
