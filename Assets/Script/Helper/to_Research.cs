using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class to_Research : MonoBehaviour
{
    public string next;
    public Button Btn;
    void Start()
    {
        Btn.GetComponent<Button>().onClick.AddListener(Click);
    }
    public void Click()
    {
        SceneManager.LoadScene(next);
    }
}
