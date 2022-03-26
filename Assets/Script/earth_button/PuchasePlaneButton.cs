using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuchasePlaneButton : MonoBehaviour
{

    public Camera c;
    // Update is called once per frame
    public void onClick()
    {
        SceneManager.LoadScene("BuyPlane");
        GlobalVariable.px = c.GetComponent<Transform>().localPosition.x;
        GlobalVariable.py = c.GetComponent<Transform>().localPosition.y;
        GlobalVariable.pz = c.GetComponent<Transform>().localPosition.z;
    }
}
