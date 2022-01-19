using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DeclineInvestmentNumButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;

    // Update is called once per frame
    public void Click()
    {
        if (Convert.ToInt32(text.text) > 0)
        {
            text.text = (Convert.ToInt32(text.text) - 1).ToString();
        }
        else
        {
            text.text = "0";
        }
    }
}
