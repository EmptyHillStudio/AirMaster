using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepWeak : MonoBehaviour
{
    /// <summary>
    /// 标记指定游戏物体的脚本不销毁，go为空时默认为该脚本挂载的GameObject
    /// </summary>
    //public GameObject go;
    public static KeepWeak Instance { get; set; }
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        /*if (go == null)
        {
            go = this.gameObject;
        }
        DontDestroyOnLoad(go);*/
    }
    private void Awake()
    {
        
    }

}
