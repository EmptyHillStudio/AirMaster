using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jindutiao : MonoBehaviour
{
    private AsyncOperation aync;
    public Image load;
    private int culload = 0;
    public Text loadtext;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadScence");
    }
    IEnumerator LoadScence()
    {
        aync = SceneManager.LoadSceneAsync("First");//��ʼ��Ϸ�ĳ���
        aync.allowSceneActivation = false;
        yield return aync;
    }

    // Update is called once per frame
    void Update()
    {
        //�ж��Ƿ��г�������
        if(aync ==null)
        {
            return;
        }
        int progrssvalue = 0;
        if (aync.progress<0.9f)
        {
            progrssvalue = (int)aync.progress * 100;
        }
        else
        {
            progrssvalue = 100;
        }
        if(culload <progrssvalue)
        {
            culload++;
            load.fillAmount = culload / 100f;
            loadtext.text = culload.ToString() + "%";
        }
        if(culload==100)
        {
            aync.allowSceneActivation = true;
        }
    }
}
