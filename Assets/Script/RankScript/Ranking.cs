using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public GameObject Lines;
    public GameObject oneline;
    public Quaternion b = new Quaternion(0, 0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 20; i++)
        {
            Vector3 a = new Vector3(180,(270-90*i), 0);
            GameObject l=Instantiate(oneline, a, b, Lines.transform);
            l.name = "line"+i.ToString() ;
            Text number = (l.transform.Find("line-number").gameObject).GetComponent<Text>();
            number.text = (i + 1).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
