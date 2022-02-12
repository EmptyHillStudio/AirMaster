using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCbutton : MonoBehaviour
{
    public GameObject ESCimage;
    bool visable = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ESCimage.SetActive(visable);
            visable = (visable ? false : true);
        }
    }
}