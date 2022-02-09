using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeButton : MonoBehaviour
{
    public GameObject noticeimage;

    // Update is called once per frame
    public void onClick()
    {
        noticeimage.SetActive(true);
    }
}
