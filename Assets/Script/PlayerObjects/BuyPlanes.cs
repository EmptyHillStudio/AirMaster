using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuyPlanes : MonoBehaviour
{
    public GameObject PlaneBoard;
    public GameObject CompanyBtn;
    public GameObject TextBoard;
    public GameObject PlanesContent;
    public GameObject Image;
    public GameObject CompanyNameInfo;
    public GameObject CompanyIntroduce;
    void Start()
    {
        CompanyBtn.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        if (!PlaneBoard.activeSelf)
        {
            PlaneBoard.SetActive(true);
            TextBoard.SetActive(false);
        }
        List<Transform> lst = new List<Transform>();
        string clickname = CompanyBtn.transform.name;
        Debug.Log("µã»÷Ãû" + clickname);
        int num = 0;
        foreach (Transform child in PlanesContent.transform)
        {
            string childName = child.gameObject.GetComponent<Owner>().ownerName;
            Image.GetComponent<Image>().sprite = CompanyBtn.GetComponent<Image>().sprite;
            CompanyNameInfo.GetComponent<Text>().text = clickname;
            if (childName == clickname)
            {
                child.gameObject.SetActive(true);
                Debug.Log(childName);
                Debug.Log(clickname);
                Debug.Log(child.name);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
