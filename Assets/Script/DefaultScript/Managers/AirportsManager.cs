using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport
{
    public int id;
    public string AirportName;
    public string City;
    public string Country;
    public string IATA;
    public string ICAO;
    public int height;
    public Airport(string id, string name, string city, string country, string iata, string icao, string height)
    {
        //Debug.Log(name);
        this.id = Convert.ToInt32(id);
        this.AirportName = name;
        this.City = city;
        this.Country = country;
        this.IATA = iata;
        this.ICAO = icao;
        this.height = Convert.ToInt32(height);
    }
}

public class AirportsManager
{
    public Dictionary<int, Airport> airportsManagers;
    public AirportsManager()
    {
        this.airportsManagers = new Dictionary<int, Airport>();
    }
    public void Add(int id, Airport a)
    {
        this.airportsManagers.Add(id, a);
    }
}
