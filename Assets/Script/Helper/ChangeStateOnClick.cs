using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeStateOnClick : MonoBehaviour
{
    public bool isChoosen;
    public GameObject Choosen;
    public void OnClick()
    {
        isChoosen = !isChoosen;
        Choosen.SetActive(isChoosen);
    }
}
