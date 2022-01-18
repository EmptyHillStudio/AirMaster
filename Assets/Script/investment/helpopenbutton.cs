using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpopenbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject board;
    public GameObject button;
    // Update is called once per frame
    public void Click()
    {
        board.SetActive(true);
        button.SetActive(false);
    }
}
