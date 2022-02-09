using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managementsituation : MonoBehaviour
{
    public GameObject show;
    public GameObject close;
    // Start is called before the first frame update
    public void Show()
    {
        show.SetActive (true);
        close.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
