using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeWindows : MonoBehaviour
{
    public Button ConfirmBtn;
    public Button CancelBtn;
    public CompanyName cName;
    public GameObject ThisWindows;
    public Text newname;
    void Start()
    {
        ConfirmBtn.GetComponent<Button>().onClick.AddListener(confirm);
        CancelBtn.GetComponent<Button>().onClick.AddListener(cancel);
    }
    void confirm()
    {
        cName.changeName(newname.text);
        ThisWindows.SetActive(false);
    }
    void cancel()
    {
        ThisWindows.SetActive(false);
    }
}
