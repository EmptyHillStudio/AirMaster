using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserchClick : MonoBehaviour
{
    private Researchcontrol rc;
    public void Click()
    {
        string name = gameObject.name;
        print(name);
        rc.Clickitem(name);
    }
}