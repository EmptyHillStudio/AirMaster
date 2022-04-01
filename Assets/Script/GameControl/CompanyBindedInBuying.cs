using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CompanyBindedInBuying : MonoBehaviour
{
    public Company BindedCompany { set; get; }
    public Image CompanyIcon;
    // Update is called once per frame
    public void Start()
    {
        this.CompanyIcon = gameObject.GetComponent<Image>();
        CompanyIcon.sprite = BindedCompany.icon;
    }
    public void Update()
    {
        
    }

    public void OnChoose()
    {
        CompaniesShowing.choosed = BindedCompany;//设置选择的公司
        //Debug.Log(CompaniesShowing.choosed.name);
        CompaniesShowing.UpdateCompanyInfo();
    }
}
