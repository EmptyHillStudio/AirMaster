using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextControl : MonoBehaviour
{
    public InputField changeT;
    public int changeindex;
    public void textChange()
    {
        //Debug.Log(changeT.text);
        int num = 1;
        if (changeT.text != "")
        {
            num = int.Parse(changeT.text);
        }
        if (num + changeindex > 0)
        {
            num += changeindex;
        }
        changeT.text = num.ToString();
    }
}
