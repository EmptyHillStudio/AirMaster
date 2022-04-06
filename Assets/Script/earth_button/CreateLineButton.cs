using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLineButton : MonoBehaviour
{
    public GameObject createLineimage;
    public void OnClick()
    {
        createLineimage.SetActive(true);
    }
}
