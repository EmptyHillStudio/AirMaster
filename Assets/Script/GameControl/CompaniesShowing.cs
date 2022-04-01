using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompaniesShowing : MonoBehaviour
{
    public static Company choosed;
    public GameObject Primary;
    public GameObject Content;
    public GameObject Attention;//未选择的文字提示
    public static List<GameObject> PlanesBoard;
    private static CompaniesShowing thisObj;
    public Image CompanyImage;
    public GameObject NullText;//当该公司没有飞机时显示的字体
    public Text CompanyName_text, CompanyIntro;
    public GameObject ChooseBoard;//选择后打开的面板
    public Image CompanyName;
    void Start()
    {
        PlanesBoard = new List<GameObject>();
        thisObj = this;
        choosed = null;
        List<Company> companies = GlobalVariable.DefaultManager.companiesManager.GetCompanies();
        foreach (Company c in companies.ToArray())
        {
            GameObject temp = GameObject.Instantiate(Primary);
            temp.transform.SetParent(Primary.transform.parent);
            CompanyBindedInBuying cbib = temp.GetComponent<CompanyBindedInBuying>();
            cbib.BindedCompany = c.GetCopiedCompany();
            temp.name = cbib.BindedCompany.name;
            if (Date.InRange(c.register, c.end, GlobalVariable.GameDate))
            {
                temp.SetActive(true);
            }
            else temp.SetActive(false);
        }
    }
    public static void UpdateCompanyInfo()
    {
        thisObj.Attention.SetActive(false);
        //Board更新
        thisObj.CompanyImage.sprite = choosed.icon;
        thisObj.CompanyName_text.text = choosed.name;
        thisObj.CompanyIntro.text = choosed.name;
        int num = 0;
        foreach (GameObject go in PlanesBoard)
        {
            BoardBindedInPlaneBuying b = go.GetComponent<BoardBindedInPlaneBuying>();
            if (b != null)
            {

                Plane p = b.BindedPlane;// 
                //Debug.Log(p.Launch.ToString() + "\t" + p.end.ToString());
                if (p.creater.name == choosed.name && Date.InRange(p.Launch, p.end, GlobalVariable.GameDate))
                {
                    num++;
                    b.gameObject.SetActive(true);
                }
                else b.gameObject.SetActive(false);
            }
            else continue;
        }
        if (num != 0)
        {
            thisObj.NullText.SetActive(false);
        }else thisObj.NullText.SetActive(true);
        thisObj.ChooseBoard.SetActive(true);
    }
}
