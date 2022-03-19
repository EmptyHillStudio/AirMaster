using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscGame_button : MonoBehaviour
{
    
    public void OnClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
