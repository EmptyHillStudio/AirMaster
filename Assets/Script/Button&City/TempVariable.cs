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

    public Dropdown captains;
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
                //设置起点和终点名
                City bCity = tempLine.GetPoints()[0], eCity = tempLine.GetPoints()[1];
                City_begin.text = bCity.name;
                City_end.text = eCity.name;
                //设置起点和终点的图像
                BeginScale.sprite = bCity.ScaleImage;
                //Debug.Log(bCity.ScaleImage.name);
                EndScale.sprite = eCity.ScaleImage;
                //设置距离和真实距离
                distance.text = "距离：" + tempLine.distance.ToString() + " km";
                distance_real.text = "真实距离：" + tempLine.real_distance.ToString() + " km";
                //增加机长选项
                Dictionary<int, PlaneCaptain> caps = GlobalVariable.DefaultManager.planeCaptainsManager.captains;
                List<Dropdown.OptionData> capOptions = new List<Dropdown.OptionData>();
                foreach(KeyValuePair<int, PlaneCaptain> pc in caps)
                {
                    if(pc.Value.state == CaptainState.FREE)
                    {
                        int an = pc.Key + 1;
                        capOptions.Add(new Dropdown.OptionData(pc.Value.name));
                        //Debug.Log(pc.Key + "\t" + pc.Value.name);
                    }
                }
                //读取服务

                //设置界面按钮状态（检测相关的科技是否解锁）

                //设置按钮的状态为全局变量的选择状态

                //计算预计满意度

                //设置下一步按钮的可用性

                captains.AddOptions(capOptions);
                

                LineCreate.SetActive(true);
                
                GlobalVariable.ChooseCity = GlobalChooseCityState.NORMAL;
                break;
        }
    }
}
