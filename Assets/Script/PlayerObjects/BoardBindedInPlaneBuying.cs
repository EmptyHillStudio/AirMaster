using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoardBindedInPlaneBuying : MonoBehaviour
{
    /// <summary>
    /// �������ڰ󶨹���ɻ������Board�ͷɻ���Ҳ������Ա����������Ҫ����ɻ���ʱ�򣬿���ֱ�ӵ��ø���ĳ�Ա
    /// </summary>
    public Plane BindedPlane;
    //public Date DateRange;
    private Image image;
    private Text Planename, price;
    private Button next;
    void Start()
    {
        Image[] images = gameObject.GetComponentsInChildren<Image>();
        foreach (Image i in images)
        {
            if(i.gameObject.name == "Icon")
            {
                this.image = i;
            }
        }
        Text[] texts = gameObject.GetComponentsInChildren<Text>();
        foreach (Text t in texts)
        {
            switch (t.gameObject.name)
            {
                case "Name":
                    Planename = t;
                    break;
                case "Price":
                    price = t;
                    break;
            }
        }
        next = gameObject.GetComponentInParent<Button>();
        image.sprite = BindedPlane.icon;
        Planename.text = BindedPlane.series + "-" + BindedPlane.sub;
        price.text = BindedPlane.price.ToString("N0");
    }

}
