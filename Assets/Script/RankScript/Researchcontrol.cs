using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Researchcontrol : MonoBehaviour
{
    public Text money, time, intro;
    private Research r;
    private static ResearchManager rmanager;
    private void Start()
    {
        rmanager = GlobalVariable.DefaultManager.researchesManager;
    }
    public void Clickitem(string UID)
    {
        r =rmanager.getResearchByUID(UID);
        money.text = (r.Money_cost).ToString ();
        time.text = (r.Time_cost).ToString();
        intro.text = (r.Introduce).ToString();
    }
}
