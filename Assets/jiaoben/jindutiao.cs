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
        aync = SceneManager.LoadSceneAsync("First");//开始游戏的场景
        aync.allowSceneActivation = false;
        yield return aync;
    }

    // Update is called once per frame
    void Update()
    {
        //判断是否有场景加载
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
