using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePause_keepStatus : MonoBehaviour
{
    public Button Btn;
    void Start()
    {
        Btn.GetComponent<Button>().onClick.AddListener(Click);
    }
    public void Click()
    {
        GlobalVariable.IsPaused = GlobalVariable.Keep;
    }
}
