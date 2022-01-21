using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCloseUI : MonoBehaviour
{
    public GameObject dropdown;
    public GameObject show;

    // Update is called once per frame
    public void Click()
    {
        dropdown.SetActive(false);
        show.SetActive(false);
    }
}
