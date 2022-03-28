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

	[ConsoleMethod("AddValueCaptain", "Add a plane captain by value, it will show the infomation in console.")]
	public static void AddCaptain_Points(float value, float investment_level)
	{
		PlaneCaptain p = PlaneCaptain.GetPointsPlaneCaptain(value, investment_level);
		p.Info();
	}
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
}
