using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventControl : MonoBehaviour
{
    

    // Update is called once per frame
    public void Update()
    {
        string date = this.GetComponent<Text>().text;
        //string year = date.Substring (7,8);
        //Debug.Log(year);
    }
    
}
