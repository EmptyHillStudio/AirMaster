using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBag_button : MonoBehaviour
{
    public GameObject image;
    // Update is called once per frame
    public void OnClick()
    {
        image.SetActive(false);
    }
}
