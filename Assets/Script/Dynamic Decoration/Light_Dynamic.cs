using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Dynamic : MonoBehaviour
{
    private GameObject Sphere;
    public int speedtimes = 1;
    void Start()
    {
        Sphere = GameObject.Find("Sphere");
    }

    void Update()
    {
        if (!GlobalVariable.IsPaused)
        {
            int times = speedtimes * speedtimes;
            transform.RotateAround(Sphere.transform.position, Vector3.up, 0.01f * times);
        }
    }
}
