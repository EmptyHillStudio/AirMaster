using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickTest()
    {
        UnityEditor.EditorUtility.DisplayDialog("关于游戏", "游戏介绍", "关闭");
    }
}
