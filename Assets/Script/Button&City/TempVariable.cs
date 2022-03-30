using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TempVariable : MonoBehaviour
{
    public CityBindToBoard InfomationBoard;
    public GameObject LineCreate;//总面板
    public Text City_begin, City_end;//起始城市的文字对象
    public Image BeginScale, EndScale;//起始城市的城市图象
    public Text distance, distance_real;
    public Line tempLine;
    public City TempCity;
    public TempVariable()
    {
        this.tempLine = new Line(0);
        this.TempCity = null;
    }
    public void Oper(City c)
    {
        ///<summary>
        /// 该方法用于改变点击城市的状态，同时将参数c传递成为临时变量，用于储存一部分信息。
        ///</summary>>
        TempCity = c;
        switch (GlobalVariable.ChooseCity)
        {
            case GlobalChooseCityState.NORMAL:
                InfomationBoard.UpdateContent(TempCity);
                break;
            case GlobalChooseCityState.CREATELINE:
                tempLine.SetPoints(1, TempCity);
                //Debug.Log("选择成功，选择的起点为：" + tempLine.GetPoints()[0].name + "，终点为：" + tempLine.GetPoints()[1].name + "，两地距离为：" + tempLine.GetDistance());
                City bCity = tempLine.GetPoints()[0], eCity = tempLine.GetPoints()[1];
                City_begin.text = bCity.name;
                City_end.text = eCity.name;
                BeginScale.sprite = bCity.ScaleImage;
                Debug.Log(bCity.ScaleImage.name);
                EndScale.sprite = eCity.ScaleImage;
                distance.text = tempLine.distance.ToString();
                distance_real.text = tempLine.real_distance.ToString();

                LineCreate.SetActive(true);
                
                GlobalVariable.ChooseCity = GlobalChooseCityState.NORMAL;
                break;
        }
    }
}
