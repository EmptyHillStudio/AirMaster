using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStop : MonoBehaviour
{
    public bool Paused;
    public Button Btn;
    void Start()
    {
        Btn.GetComponent<Button>().onClick.AddListener(Click);
    }
    public void Click()
    {
        GlobalVariable.Keep = GlobalVariable.IsPaused;
        GlobalVariable.IsPaused = Paused;
    }
}
