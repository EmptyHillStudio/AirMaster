using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputfield : MonoBehaviour
{

    
    
    void Start()
    {
        transform.GetComponent<InputField>().onValueChanged.AddListener(Change_Value);
        transform.GetComponent<InputField>().onEndEdit.AddListener(End_Value);
    }
    public void Change_Value(string inp)
    {
        Debug.Log("正在输入" + inp);
    }
    public void End_Value(string inp)
    {
        print("文本内容" + inp);
        // Start is called before the first frame update

    }
}
