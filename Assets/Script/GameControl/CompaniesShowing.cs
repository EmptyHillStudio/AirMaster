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
        companies = GlobalVariable.DefaultManager.companiesManager.GetInDateCompanies();
        foreach (Company c in companies)
        {
            GameObject temp = GameObject.Instantiate(Primary);
            Sprite logo = Resources.Load("Companies/" + temp.name, typeof(Sprite)) as Sprite;
            temp.GetComponent<Image>().sprite = logo;
            temp.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
