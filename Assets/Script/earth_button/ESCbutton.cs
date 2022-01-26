using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCbutton : MonoBehaviour
{
    public GameObject ESCimage;

    // Update is called once per frame
    public void OnClick()
    {
        ESCimage.SetActive(true);
    }
}
