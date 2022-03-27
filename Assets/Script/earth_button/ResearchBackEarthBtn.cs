using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResearchBackEarthBtn : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("earth");
    }
}
