using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBoard : MonoBehaviour
{
    public Button Open_Btn;
    public GameObject Opened_Board;
    void Start()
    {
        Open_Btn.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        Opened_Board.SetActive(true);
    }
}
