using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Rankbutton : MonoBehaviour
{
    public Camera c;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rankclick()
    {
        SceneManager.LoadScene(5);
        GlobalVariable.px = c.GetComponent<Transform>().localPosition.x;
        GlobalVariable.py = c.GetComponent<Transform>().localPosition.y;
        GlobalVariable.pz = c.GetComponent<Transform>().localPosition.z;
    }
}
