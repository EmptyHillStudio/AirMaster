using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepWeak : MonoBehaviour
{
    /// <summary>
    /// ���ָ����Ϸ����Ľű������٣�goΪ��ʱĬ��Ϊ�ýű����ص�GameObject
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
