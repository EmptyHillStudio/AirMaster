using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class showOriginalDate : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = GlobalVariable.GameDate.ToString();
    }

    
}
