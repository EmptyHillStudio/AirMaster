using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country
{
    private string Country_Code;
    private string Name;
    private string Type;
    private List<string> sign;
    public Country(string country_code, string name, string type, string signs)
    {
        this.Country_Code = country_code;
        this.Name = name;
        this.Type = type;
        sign = new List<string>();
        string[] split = signs.Split(';');
        foreach (string s in split)
        {
            sign.Add(s);
        }
    }
}

public class CountriesManager
{
    public Dictionary<string, Country> countries;
    public List<string> countriesName;
    public CountriesManager()
    {
        this.countries = new Dictionary<string, Country>();
        countriesName = new List<string>();
    }

    public void Add(string name, Country country)
    {
        this.countries.Add(name, country);
        this.countriesName.Add(name);
    }
    public Country GetCountry(string name)
    {
        return countries[name];
    }
}
