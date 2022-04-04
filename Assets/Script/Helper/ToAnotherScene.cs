using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToAnotherScene : MonoBehaviour
{
    public string SceneName;
    public bool BackToEarth = true;
    public bool keepCarmera = false;
    public bool keepTime = false;
    public void OnTrick()
    {
        if (BackToEarth)
        {
            SceneManager.LoadScene(SceneName);
        }
        else
        {

        }
    }
}
