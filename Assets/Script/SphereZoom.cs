using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class SphereZoom : MonoBehaviour
{
    private int minView = 10;
    private int maxView = 80;
    private Camera c;        
    
    // Start is called before the first frame update
    void Start()
    {
        c = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var Sphere = GameObject.Find("Sphere");
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (c.fieldOfView <= maxView && c.fieldOfView > minView)
            {
                c.fieldOfView -= 2 + 2 * Math.Abs(Input.GetAxis("Mouse ScrollWheel"));
            }
            if (c.fieldOfView <= minView)
            {
                this.GetComponent<Camera>().fieldOfView = minView;
            }

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (c.fieldOfView < maxView&& c.fieldOfView >= minView)
            {
                c.fieldOfView += 2 + 2 * Math.Abs(Input.GetAxis("Mouse ScrollWheel")); ;
            } 
            if (c.fieldOfView >= maxView)
            {
                this.GetComponent<Camera>().fieldOfView = maxView;
            }
            
        }

    }
}
