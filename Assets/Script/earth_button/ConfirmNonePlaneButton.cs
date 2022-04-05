using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmNonePlaneButton : MonoBehaviour
{
    public GameObject Noneimage;
    public void OnClick()
    {
        Noneimage.SetActive(false);
    }
}
