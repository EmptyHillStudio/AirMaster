using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startskip : MonoBehaviour
{

    public void OnClick() 
    { 
    
        SceneManager.LoadScene("setting");
    }
}
