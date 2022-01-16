using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board_close : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject board;
    // Update is called once per frame
    public void Click()
    {
        board.SetActive(false);

    }
}
