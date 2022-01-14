using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CompanyName : MonoBehaviour
{
    public Text namefield;
    void Start()
    {
        namefield.text = GlobalVariable.CompanyName;
    }
     public void changeName(string Name)
    {
        GlobalVariable.CompanyName = Name;
        namefield.text = GlobalVariable.CompanyName;
    }
}
