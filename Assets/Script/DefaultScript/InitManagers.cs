using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour
{
    //���ԴӸù����������л�ȡ�Ѷ�ȡ�����ݣ���ÿ�����ݶ�����Ҫ�ڸ��Ե����ļ���������
    public  CitiesManager cities_manager;//���ж��������
    public  LinesManager lines_manager;//���߹�����
    public  DateManager date_manager;//���ڹ�����
    public ThumbnailImageManager thumbnailImageManager;//��ģͼ�������
    void Start()
    {
        this.cities_manager = DataLoader.getManager();
        this.lines_manager = new LinesManager();
        if(GlobalVariable.GameDate == null)
        {
            GlobalVariable.GameDate = new Date(1960, 1, 1);
        }
        GlobalVariable.DefaultManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
