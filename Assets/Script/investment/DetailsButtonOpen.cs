using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailsButtonOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject board;
    public GameObject lastboard;
    // Update is called once per frame
    public void Click()
    {
        lastboard.SetActive(false);
        board.SetActive(true);
    }
}
