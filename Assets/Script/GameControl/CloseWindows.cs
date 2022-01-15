using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWindows : MonoBehaviour
{
    public GameObject ClosedWindows;
    public Button CloseBtn;
    void Start()
    {
        CloseBtn.GetComponent<Button>().onClick.AddListener(Close);
    }
    void Close()
    {
        ClosedWindows.SetActive(false);
    }
}
