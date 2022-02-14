using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuchasePlaneButton : MonoBehaviour
{
    

    // Update is called once per frame
    public void onClick()
    {
        SceneManager.LoadScene("BuyPlane");
    }
}
