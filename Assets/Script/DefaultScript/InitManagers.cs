using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour
{
    //���ԴӸù����������л�ȡ�Ѷ�ȡ�����ݣ���ÿ�����ݶ�����Ҫ�ڸ��Ե����ļ���������
    public CitiesManager cities_manager;//���ж��������
    public LinesManager lines_manager;//���߹�����
    public DateManager date_manager;//���ڹ�����
    public ThumbnailImageManager thumbnailImageManager;//��ģͼ�������
    public AirportsManager airportsManager;
    public CountriesManager countriesManager;
    public CompaniesManager companiesManager;
    public PlanesManager planesManager;
    public ResearchManager researchesManager;
    void Start()
    {
        GlobalVariable.DefaultManager = this;
        //��ȡ���ݵ�˳��һ�������ң�����ᱨNullPointerException
        //1�ȶ�ȡ�������ݣ���֤�������ݻ�ȡ����ʱ�ܹ��õ����Ҷ���
        this.countriesManager = DataLoader.GetCountriesManager();
        //2��ȡ��������
        this.cities_manager = DataLoader.getManager();
        //3��ȡ���ֹ�˾�����ݣ���ʼ�����߹�����
        this.companiesManager = DataLoader.GetCompaniesManager();
        this.lines_manager = new LinesManager();
        //4��ȡ������ʷ�ͻ�������
        this.planesManager = DataLoader.GetPlanesManager();
        //5��ȡ���л���������
        this.airportsManager = DataLoader.GetAirportsManager();
        //6��ȡ�Ƽ����о�����
        this.researchesManager = DataLoader.GetResearchesManager();
        //7��ȡ������������

        //8
        if (GlobalVariable.GameDate == null)
        {
            GlobalVariable.GameDate = new Date(1970, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
