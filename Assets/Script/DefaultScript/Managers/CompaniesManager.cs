using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Company
{
    public Company_Type type;
    public string name;
    public Date register;
    public Date end;
    public Country owner;
    public Company(string name, Country country, Date reg, Date end, Company_Type type)
    {
        this.name = name;
        this.owner = country;
        this.register = reg;
        this.end = end;
        this.type = type;
    }

    public Company(string name, string country, string reg, string end, string type)
    {
        this.name = name;
        this.owner = GlobalVariable.DefaultManager.countriesManager.GetCountry(country);
        this.register = new Date(reg);
        this.end = new Date(end);
        this.type = Company.GetType(type);
    }

    public static Company_Type GetType(string data)
    {
        switch (data)
        {
            case "AIRPORT":
                return Company_Type.AIRPORT;
            case "AIRLINE":
                return Company_Type.AIRLINE;
            case "AIRCRAFT":
                return Company_Type.AIRCRAFT;
            default:
                return Company_Type.NULL;
        }
    }
}

public enum Company_Type
{ 
    AIRPORT, //机场公司
    AIRLINE, //航空公司
    AIRCRAFT, //飞机制造企业
    NULL
}

public class CompaniesManager
{
    private Dictionary<string, Company> AircraftCompanies;
    
    public CompaniesManager()
    {
        this.AircraftCompanies = new Dictionary<string, Company>();
    }
    public void Add(Company company)
    {
        this.AircraftCompanies.Add(company.name, company);
    }
    public Company GetCompany(string name)
    {
        return AircraftCompanies[name];
    }
    public List<Company> GetInDateCompanies()
    {
        List<Company> temp = new List<Company>();
        Date now = GlobalVariable.GameDate;
        foreach(Company c in AircraftCompanies.Values)
        {
            if (Date.InRange(c.register, c.end, now)) 
            {
                temp.Add(c);
            }
        }
        return temp;
    }
}
