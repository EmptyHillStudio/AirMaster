using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ServiceResearchCon : MonoBehaviour
{
    public static ServiceShowing showing;
    public GameObject BoardsParent;//服务界面管理面板
    public static Research ClickResearch;
    public GameObject CanResearch, Researched, Researching, PreResearch;
    public GameObject NoEnoughMoney;
    void Start()
    {
        
    }
    public void UpdateBoard()
    {
        //Debug.Log(ClickResearch.Status.ToString());
        switch (ClickResearch.Status)
        {
            case ResearchStatus.FINISHED:
                CanResearch.SetActive(false);
                Researched.SetActive(true);
                Researching.SetActive(false);
                break;
            case ResearchStatus.PROGRESSING:
                CanResearch.SetActive(false);
                Researched.SetActive(false);
                Researching.SetActive(true);
                break;
            case ResearchStatus.UNSTARTED:
                Researched.SetActive(false);
                Researching.SetActive(false);
                CanResearch.SetActive(true);
                break;
        }
        gameObject.SetActive(true);
    }
    public void OnResearch()
    {
        if (!ClickResearch.IsLocked())
        {
            PreResearch.SetActive(true);
            return;
        }
        if ((GlobalVariable.Money - ClickResearch.Money_cost).index >= 0)
        {
            GlobalVariable.Money -= ClickResearch.Money_cost;
            Date now = GlobalVariable.GameDate;
            GlobalVariable.DefaultManager.researchesManager.getResearchByUID(ClickResearch.UID).Starttime = new Date(
                now.year, now.month, now.day);
            GlobalVariable.DefaultManager.researchesManager.getResearchByUID(ClickResearch.UID).Status = ResearchStatus.PROGRESSING;
            ResearchManager.Researching.Add(ClickResearch.UID, ClickResearch);
            showing.Researching.SetActive(true);
            showing.Locked.SetActive(false);
        }
        else NoEnoughMoney.SetActive(true);
        UpdateBoard();
    }
    public void CancelResearch()
    {
        GlobalVariable.DefaultManager.researchesManager.getResearchByUID(ClickResearch.UID).Starttime = null;
        GlobalVariable.DefaultManager.researchesManager.getResearchByUID(ClickResearch.UID).Status = ResearchStatus.UNSTARTED;
        ResearchManager.Researching.Remove(ClickResearch.UID);
        UpdateBoard();
        showing.Researching.SetActive(false);
        showing.Locked.SetActive(true);
    }
}
