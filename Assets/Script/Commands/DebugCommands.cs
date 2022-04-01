using System;
using System.Collections;
using System.Collections.Generic;
using IngameDebugConsole;
using UnityEngine;

public class DebugCommands : MonoBehaviour
{
	[ConsoleMethod("CaptainsNum", "Get all captains' information.")]
	public static void GetInfoMation()
	{
		Debug.Log("所有机长数量为：" + GlobalVariable.DefaultManager.planeCaptainsManager.captains.Count);
	}
	/// <summary>
	/// 生成指定分数的机长，并显示相应的信息
	/// </summary>
	/// <param name="value">生成机长的分数</param>
	[ConsoleMethod("AddValueCaptain", "Add a plane captain by value, it will show the infomation in console.")]
	public static void AddCaptain_Points(float value)
	{
		PlaneCaptain p = PlaneCaptain.GetPointsPlaneCaptain(value);
		p.Info();
		Debug.Log(MathModel.GetCaptainValue(p));
	}
	/// <summary>
	/// 根据投资等级和城市名生成一个随机机长
	/// </summary>
	/// <param name="investment_level">投资等级</param>
	/// <param name="cityName">城市名</param>
	[ConsoleMethod("AddCityCaptain", "Add a plane captain by city's name, it will show the infomation in console.")]
	public static void AddCaptain_City(float investment_level, string cityName)
	{
		PlaneCaptain p;
		try
		{
			City c = GlobalVariable.DefaultManager.cities_manager.getCityByName(cityName);
			p = PlaneCaptain.GetRandomPlaneCaptain(investment_level, c);
			p.Info();
		}
		catch(NullReferenceException)
		{
			Debug.Log("City " + cityName + " is not existed!");
		}
	}
	/// <summary>
	/// 增加指定数量的金钱
	/// </summary>
	/// <param name="value">money's value</param>
	[ConsoleMethod("cash", "Add money.")]
	public static void cash(float value)
	{
		GlobalVariable.Money += value;
	}
	/// <summary>
	/// 清除债务
	/// </summary>
	[ConsoleMethod("ClearDebt", "Clear debt.")]
	public static void ClearDebt()
	{
		GlobalVariable.Debt.index =0;
	}
	/// <summary>
	/// 显示债务
	/// </summary>
	[ConsoleMethod("Debt", "Show your debt.")]
	public static void ShowDebt()
	{
		Debug.Log(GlobalVariable.Debt.ToString());
	}
	/// <summary>
	/// 强行显示一个GameObject对象
	/// </summary>
	/// <param  name="name">GameObject's name</param>
	[ConsoleMethod("ForceShow", "Forced display GameObject(UI_canvas) by name.")]
	public static void ForceShow(string name)
	{
		GameObject[] goes = Resources.FindObjectsOfTypeAll<GameObject>();
		int num = 0;
		foreach (GameObject go in goes)
		{
			if (go.name == name)
			{
				go.SetActive(true);
				num++;
			}
		}
		if (num != 0) Debug.Log("找到了名为 \"" + name + "\" 的GameObject " + num + " 个");
		else Debug.Log("未找到名为 \"" + name + "\" 的GameObject"); 

	}
}
