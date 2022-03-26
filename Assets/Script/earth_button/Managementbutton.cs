using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managementbutton : MonoBehaviour
{
    public Camera c;
    public void Managementclick()
    {
        SceneManager.LoadScene(7);
        GlobalVariable.px = c.GetComponent<Transform>().localPosition.x;
        GlobalVariable.py = c.GetComponent<Transform>().localPosition.y;
        GlobalVariable.pz = c.GetComponent<Transform>().localPosition.z;
    }
}
