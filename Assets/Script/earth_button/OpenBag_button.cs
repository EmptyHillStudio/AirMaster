using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBag_button : MonoBehaviour
{
    public GameObject image;

    // Update is called once per frame
    public void OnClick()
    {
        image.SetActive(true);
    }
}
