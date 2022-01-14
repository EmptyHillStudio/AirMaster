using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    public Button ChangeNameButton;
    public GameObject Window;
    void Start()
    {
        ChangeNameButton.GetComponent<Button>().onClick.AddListener(change);
    }

    void change()
    {
        Window.SetActive(true);

    }
}
