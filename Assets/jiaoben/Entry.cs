using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Entry : MonoBehaviour
{
    public GameObject about;
    private bool flag;
    public static int ctrlflag = 1;
    public Text ctrltext;
    public Text Button1;
    public Text Button2;

    private int ResoType = 1;
    public Text ResoText;

    public Text AboutText;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResolutionSet();
        }
    }

    public void StartGame()
    {
        if (flag == false)
        {
            SceneManager.LoadScene("earth");
        }
        else
        {
            Application.OpenURL("https://blog.csdn.net/weixin_43673589");
        }

    }

    public void About()
    {
        //显示游戏介绍
        if (flag == false)
        {
            //介绍文本显示
            about.SetActive(true);
            flag = true;

            //按钮1从开始游戏变更为博客
            Button1.text = "作者博客";
            Button1.fontSize = 32;

            //按钮1从开始游戏变更为博客
            Button2.text = "课设回顾";
            Button2.fontSize = 32;

            //关于按钮变为关闭按钮
            AboutText.text = "×";
            AboutText.fontSize = 140;

            return;
        }

        //隐藏游戏介绍
        if (flag == true)
        {
            about.SetActive(false);
            flag = false;

            //按钮1从开始游戏变更为博客
            Button1.text = "开始";
            Button1.fontSize = 49;

            //按钮1从开始游戏变更为博客
            Button2.text = "鼠标+键盘";
            Button2.fontSize = 28;

            //关闭按钮变为关于按钮
            AboutText.text = "关于";
            AboutText.fontSize = 49;

            return;
        }
    }

    public void Blog()
    {
        Application.OpenURL("https://blog.csdn.net/weixin_43673589");
    }

    public void ctrl()
    {
        if (flag == false)
        {
            Debug.Log(ctrlflag);
            if (ctrlflag == 1)
            {
                ctrlflag = 2;
                ctrltext.text = "鼠标";
                ctrltext.fontSize = 49;
            }
            else if (ctrlflag == 2)
            {
                ctrlflag = 3;
                ctrltext.text = "键盘";
                ctrltext.fontSize = 49;
            }
            else if (ctrlflag == 3)
            {
                ctrlflag = 1;
                ctrltext.text = "鼠标+键盘";
                ctrltext.fontSize = 28;
            }
        }
        else
        {
            Application.OpenURL("https://blog.csdn.net/weixin_43673589/article/details/106577768");
        }
    }

    public void ResolutionSet()
    {
        if (ResoType % 2 == 0)
        {
            Screen.SetResolution(1155, 763, false, 60);
            ResoType++;
            ResoText.text = "窗口";
            return;
        }
        if (ResoType % 2 == 1)
        {
            Screen.SetResolution(2160, 1440, true, 60);
            ResoType++;
            ResoText.text = "全屏";
            return;
        }
    }
}