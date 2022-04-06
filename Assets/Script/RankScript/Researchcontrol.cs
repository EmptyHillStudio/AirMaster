using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Researchcontrol : MonoBehaviour
{
    public Button lighten;
    private Text money, time, intro, status;
    public GameObject items, board;
    private Research r;
    private static ResearchManager rmanager;
    private Date datecount;
    string[] UIDS = new string[30];
    private void Start()
    {
        rmanager = GlobalVariable.DefaultManager.researchesManager;
        foreach (Transform tra in items.transform)//批量挂载脚本
        {
            GameObject one = tra.gameObject;
            one.AddComponent<Researchcontrol>();
            Button a = one.GetComponent<Button>();//onclick()的监听事件不知道为什么挂不上去
            a.onClick.AddListener(Showinfo);
        }
        datecount = GlobalVariable.GameDate;
    }
    private void Update()
    {
        if (datecount != GlobalVariable.GameDate)//每天检测
        {
            Statusjudge();
            datecount = GlobalVariable.GameDate;
            // print ()
        }
    }
    public void Showinfo()//展示详情
    {
        board = GameObject.Find("info");
        board.SetActive(true);
        money = GameObject.Find("money").GetComponent<Text>();
        time = GameObject.Find("time").GetComponent<Text>();
        intro = GameObject.Find("intro").GetComponent<Text>();
        status = GameObject.Find("status").GetComponent<Text>();
        string name = gameObject.name;
        GetR(name);
        money.text = (r.Money_cost).ToString();
        time.text = (r.Time_cost).ToString();
        intro.text = (r.Introduce).ToString();
        if (r.Status == ResearchStatus.UNSTARTED)
            status.text = "unstarted";
        else if (r.Status == ResearchStatus.PROGRESSING)
            status.text = "progressing";
        else if (r.Status == ResearchStatus.FINISHED)
            status.text = "finished";
    }
    public void GetR(string UID)
    {
        r = rmanager.getResearchByUID(UID);
    }

    public void Lighten()//开始研究某项
    {
        bool preJudge = true;
        string[] pre = r.Pre_researches;
        string name = r.UID;
        foreach (string one in pre)
        {
            Research a = rmanager.getResearchByUID(one);
            if (a.Status != ResearchStatus.FINISHED)
                preJudge = false;
        }
        if (preJudge == true)
        {
            r.Status = ResearchStatus.PROGRESSING;
            r.Starttime = datecount;
        }
    }
    public void Statusjudge()//判断正在进行的研究情况
    {
        foreach (Research R in rmanager.Researches.Values)
        {
            if (R.Status == ResearchStatus.PROGRESSING)
            {
                int x = Date.TimeDifference(R.Starttime, datecount);
                if (x >= R.Time_cost)
                    R.Status = ResearchStatus.FINISHED;
            }

        }

    }
}
