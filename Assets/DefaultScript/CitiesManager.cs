using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{
    private string name;
    private double x;
    private double y;
    public City(string name, double x, double y)
    {
        this.name = name;
        this.x = x;
        this.y = y;
    }
    string getName()
    {
        return name;
    }
    double getX()
    {
        return x;
    }
    double getY()
    {
        return y;
    }
}

public class CitiesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
