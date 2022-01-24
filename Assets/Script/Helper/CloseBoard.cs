using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBoard : MonoBehaviour
{
    public Button Close_Btn;
    public GameObject Closed_Board;
    void Start()
    {
        Close_Btn.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        Closed_Board.SetActive(false);
    }
}
