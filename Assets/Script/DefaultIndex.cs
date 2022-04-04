using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DefaultIndex : MonoBehaviour
{
    public Text def;
    public int defin;
    void Start()
    {
        def.text = defin.ToString();
    }

}
