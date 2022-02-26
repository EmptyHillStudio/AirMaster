using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCbutton : MonoBehaviour
{
    public GameObject ESCimage;
    bool visable = true;
    public void Onclick()
    {
        ESCimage.SetActive(visable);
        visable = (visable ? false : true);
    }
}