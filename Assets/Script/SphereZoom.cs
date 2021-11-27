using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereZoom : MonoBehaviour
{
    private int minView = 10;
    private int maxView = 80;
    private int midView = 50;
    private int slideSpeed = 20;
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
            Sphere.transform.Translate(Vector3.forward * 0.5f);
            if (c.fieldOfView <= maxView && c.fieldOfView > minView)
            {
                c.fieldOfView -= 2;
            }
            if (c.fieldOfView <= minView)
            {
                this.GetComponent<Camera>().fieldOfView = minView;
            }

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Sphere.transform.Translate(Vector3.forward * -0.5f);
            if (c.fieldOfView < maxView&& c.fieldOfView >= minView)
            {
                c.fieldOfView += 2;
            } 
            if (c.fieldOfView >= maxView)
            {
                this.GetComponent<Camera>().fieldOfView = maxView;
            }
            
        }

    }
}
