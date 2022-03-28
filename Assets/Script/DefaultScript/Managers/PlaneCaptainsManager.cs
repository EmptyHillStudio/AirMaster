using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCaptainsManager
{
    int id = 0;
    public Dictionary<int, PlaneCaptain> captains;
    public PlaneCaptainsManager()
    {
        this.captains = new Dictionary<int, PlaneCaptain>();
    }
    public void Add(PlaneCaptain planeCaptain)
    {
        this.captains.Add(id, planeCaptain);
        id++;
    }
    public void Remove(int id)
    {
        this.captains.Remove(id);
    }
}
