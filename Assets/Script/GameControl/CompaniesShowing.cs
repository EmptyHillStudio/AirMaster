using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompaniesShowing : MonoBehaviour
{
    List<Company> companies;
    public GameObject Primary;
    public GameObject Content;
    void Start()
    {
        companies = GlobalVariable.DefaultManager.companiesManager.GetCompanies();
        foreach (Company c in companies)
        {
            GameObject temp = GameObject.Instantiate(Primary);
            Sprite logo = Resources.Load("Companies/" + c.name, typeof(Sprite)) as Sprite;
            temp.GetComponent<Image>().sprite = logo;
            temp.transform.SetParent(Content.transform);
            temp.name = c.name;
            Date now = GlobalVariable.GameDate;
            if (Date.InRange(c.register, c.end, now))
            {
                temp.SetActive(true);
            }else temp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
