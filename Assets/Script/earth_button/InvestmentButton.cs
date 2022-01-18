using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvestmentButton : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void Click()
    {
        SceneManager.LoadScene("investment");
    }
}
