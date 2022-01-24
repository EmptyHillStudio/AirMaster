using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public GameObject EscapeBoard;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeBoard.SetActive(true);
        }
    }
}
