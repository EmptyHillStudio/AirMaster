using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRecover : MonoBehaviour
{
    public Camera c;
    void Start()
    {
        c.GetComponent<Camera>().fieldOfView = GlobalVariable.fieldOfView;
       
        c.transform.localEulerAngles = new Vector3(GlobalVariable.rx, GlobalVariable.ry, GlobalVariable.rz);
        c.transform.localPosition = new Vector3(GlobalVariable.px, GlobalVariable.py, GlobalVariable.pz);
    }
}
