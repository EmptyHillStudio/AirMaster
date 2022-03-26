using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class to_Research : MonoBehaviour
{
    public string next;
    public Button Btn;
    public Camera c;
    void Start()
    {
        Btn.GetComponent<Button>().onClick.AddListener(Click);
    }
    public void Click()
    {
        SceneManager.LoadScene(next);
        GlobalVariable.px = c.GetComponent<Transform>().localPosition.x;
        GlobalVariable.py = c.GetComponent<Transform>().localPosition.y;
        GlobalVariable.pz = c.GetComponent<Transform>().localPosition.z;
    }
}
