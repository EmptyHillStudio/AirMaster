using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{
    public string ownerName;
    public int year;
    public int month;
    public int day;
    public int age;
    public void setName(string newname)
    {
        ownerName = newname;
    }
    void Start()
    {
        this.ownerName = "";
    }
}
