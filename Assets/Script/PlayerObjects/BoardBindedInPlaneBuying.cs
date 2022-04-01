using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoardBindedInPlaneBuying : MonoBehaviour
{
    /// <summary>
    /// 该类用于绑定购买飞机界面的Board和飞机，也有许多成员变量，当需要购买飞机的时候，可以直接调用该类的成员
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
