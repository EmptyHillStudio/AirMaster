using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Dynamic : MonoBehaviour
{
    private GameObject Sphere;
    void Start()
    {
        Sphere = GameObject.Find("Sphere");
    }

    void Update()
    {
        if (!GlobalVariable.IsPaused)
        {
            transform.RotateAround(Sphere.transform.position, Vector3.up, 0.01f);
        }
    }
}
