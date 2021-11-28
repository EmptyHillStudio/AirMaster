using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class textshowcmpname : MonoBehaviour
{
    public Text text;
    public InputField inputfield;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        text.GetComponent<Text>().text = inputfield.GetComponent<Text>().text;
    }
   
}
