using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCbutton : MonoBehaviour
{
    public GameObject ESCimage;
    private bool flag = false;
    void Start()
    {
        ESCimage.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!flag)
            {
                ESCimage.SetActive(true);
                flag = true;
            }
            else
            {
                ESCimage.SetActive(false);
                flag = false;
            }
        }
    }
}