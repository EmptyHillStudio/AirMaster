using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGameButton : MonoBehaviour
{
    public GameObject escImage;
    public void OnClick()
    {
        escImage.SetActive(false);
    }
}
