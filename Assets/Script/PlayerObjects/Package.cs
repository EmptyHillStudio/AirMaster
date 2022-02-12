using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Package : MonoBehaviour
{
    public List<Plane> Planes;
    private float Money;
    private float Prestige;
    public Text MoneyInfo;
    public Text PrestigeInfo;
    void Start()
    {
        SetMoney(10000);
        SetPrestige(0);
    }
    
    public void SetMoney(float NewIndex)
    {
        this.Money = NewIndex;
    }

    public void SetPrestige(float NewPrestige)
    {
        this.Prestige = NewPrestige;
    }

    public float GetMoney()
    {
        return Money;
    }

    public float GetPrestige()
    {
        return Prestige;
    }
    // Update is called once per frame
    void Update()
    {
        MoneyInfo.GetComponent<Text>().text = Money.ToString("N0");
        PrestigeInfo.GetComponent<Text>().text = Prestige.ToString("N0");
    }
}
