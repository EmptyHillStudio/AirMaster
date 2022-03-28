using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelepicTestScript : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        /*//过程模拟
        for(int i = 2000; i < 3000; i += 100)
        {
            double sum = 0;
            Debug.Log("生成" + i + "分数的机长");
            for (int k = 0; k < 10; k++) 
            {
                PlaneCaptain planeCaptain = PlaneCaptain.GetPointsPlaneCaptain(i, 5);
                double value = MathModel.GetCaptainValue(planeCaptain);
                sum += value;
            }
            Debug.Log("生成10个机长的平均分数为：" + sum / 10);
        }
        //*/

    }
}
