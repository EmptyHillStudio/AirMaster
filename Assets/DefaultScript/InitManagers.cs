using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour
{
    //���ԴӸù����������л�ȡ�Ѷ�ȡ�����ݣ���ÿ�����ݶ�����Ҫ�ڸ��Ե����ļ���������
    private CitiesManager cities_manager;
    void Start()
    {
        this.cities_manager = DataLoader.getManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
