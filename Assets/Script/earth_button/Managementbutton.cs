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
        GlobalVariable.fieldOfView = c.GetComponent<Camera>().fieldOfView;
        GlobalVariable.rx = c.GetComponent<Transform>().eulerAngles.x;
        GlobalVariable.ry = c.GetComponent<Transform>().eulerAngles.y;
        GlobalVariable.rz = c.GetComponent<Transform>().eulerAngles.z;
    }
}
