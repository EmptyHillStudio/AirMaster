using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeValueButton : MonoBehaviour
{

    public GameObject text;
    // Update is called once per frame
    public void OnClick()
    {
        text.GetComponent<Text>().text=(Convert.ToInt32(text.GetComponent<Text>().text) + 1).ToString();
    }
}
