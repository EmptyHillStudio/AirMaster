using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour
{
    //���ԴӸù����������л�ȡ�Ѷ�ȡ�����ݣ���ÿ�����ݶ�����Ҫ�ڸ��Ե����ļ���������
    private CitiesManager cities_manager;
    private LinesManager lines_manager;
    void Start()
    {
        this.cities_manager = DataLoader.getManager();
        this.lines_manager = new LinesManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
