using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityDetailsbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject board;
    public GameObject lastboard;

    // Update is called once per frame
    public void Click()
    {
        board.SetActive(true);
        lastboard.SetActive(false);
    }
}
