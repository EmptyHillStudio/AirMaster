using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvestmentButton : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera c;
    // Update is called once per frame
    public void Click()
    {
        SceneManager.LoadScene("investment");
        GlobalVariable.px = c.GetComponent<Transform>().localPosition.x;
        GlobalVariable.py = c.GetComponent<Transform>().localPosition.y;
        GlobalVariable.pz = c.GetComponent<Transform>().localPosition.z;
    }
}
