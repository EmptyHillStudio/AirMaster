using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ServiceShowing : MonoBehaviour
{
    public ServiceResearchCon BoardScript;//界面的绑定脚本
    public Text money, time, intro, status;
    private Research research;
    public GameObject Researching, Locked;
    private void Start()
    {
        Transform[] Ts = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform t in Ts)
        {
            switch (t.gameObject.name)
            {
                case "Locked":
                    Locked = t.gameObject;
                    break;
                case "Researching":
                    Researching = t.gameObject;
                    break;
            }
        }
        research = GlobalVariable.DefaultManager.researchesManager.getResearchByUID(gameObject.name);
        Button click = gameObject.GetComponent<Button>();
        switch (research.Status)
        {
            case ResearchStatus.FINISHED:
                Researching.SetActive(false);
                Locked.SetActive(false);
                break;
            case ResearchStatus.PROGRESSING:
                Researching.SetActive(true);
                Locked.SetActive(false);
                break;
            case ResearchStatus.UNSTARTED:
                Researching.SetActive(false);
                Locked.SetActive(true);
                break;
        }
        click.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        money.text = research.Money_cost.ToString();
        time.text = research.Time_cost.ToString() + " day";
        intro.text = research.Introduce;
        status.text = research.Status.ToString();
        ServiceResearchCon.ClickResearch = research;
        ServiceResearchCon.showing = this;
        BoardScript.UpdateBoard();
    }
}
