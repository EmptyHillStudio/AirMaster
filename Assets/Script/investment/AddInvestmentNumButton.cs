using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class AddInvestmentNumButton : MonoBehaviour
{
    
    public Text text;
    // Update is called once per frame
    public void Click()
    {

        
        text.text= (Convert.ToInt32(text.text)+1).ToString();
    }
}
