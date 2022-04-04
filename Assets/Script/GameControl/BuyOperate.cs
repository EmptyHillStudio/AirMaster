using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuyOperate : MonoBehaviour
{
    public InputField number;
    public GameObject successBoard;
    public GameObject Faild;
    public void Onclick()
    {
        BoardBindedInPlaneBuying bbpb = LoadingPlanes.tradeBoard;
        
        int num = 1;
        if(number.text != "")
        {
            num = int.Parse(number.text);
        }
        float money = float.Parse(GlobalVariable.Money.GetValue().ToString());
        if (money > num * bbpb.BindedPlane.price) 
        {//钱足够则实现购买操作
            GlobalVariable.Money -= bbpb.BindedPlane.price;
            int BagNum = GlobalVariable.planeDic[bbpb.BindedPlane];
            GlobalVariable.planeDic[bbpb.BindedPlane] = BagNum + num;
            number.text = "1";
            successBoard.SetActive(true);
        }
        else
        {
            number.text = "1";
            Faild.SetActive(true);
        }
    }
}
