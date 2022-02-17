using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetCompanyPlanes : MonoBehaviour
{
    public Button btn;
    void Start()
    {
        
        btn.GetComponent<Button>().onClick.AddListener(Click);
        
    }
    void Click()
    {

    }
}
