using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CostShow : MonoBehaviour
{
    public Text showingArea;
    public static PlayerPoints showingtext;
    public InputField number;
    public BoardBindedInPlaneBuying bbpb;

    void Start()
    {
        bbpb = LoadingPlanes.tradeBoard;
        int num = 1;
        if (number.text != "")
        {
            num = int.Parse(number.text);
        }
        showingtext = new PlayerPoints(num * bbpb.BindedPlane.price);
        showingArea.text = "Estimated cost: " + showingtext.ToString();
    }
    public void OnChange()
    {
        int num = 1;
        if (number.text != "")
        {
            num = int.Parse(number.text);
        }
        showingtext = new PlayerPoints(num * bbpb.BindedPlane.price);
        showingArea.text = "Estimated cost: " + showingtext.ToString();
    }
}
