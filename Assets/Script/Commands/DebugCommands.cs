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
		Debug.Log("���л�������Ϊ��" + GlobalVariable.DefaultManager.planeCaptainsManager.captains.Count);
	}
	/// <summary>
	/// ����ָ�������Ļ���������ʾ��Ӧ����Ϣ
	/// </summary>
	/// <param name="value">���ɻ����ķ���</param>
	[ConsoleMethod("AddValueCaptain", "Add a plane captain by value, it will show the infomation in console.")]
	public static void AddCaptain_Points(float value)
	{
		PlaneCaptain p = PlaneCaptain.GetPointsPlaneCaptain(value);
		p.Info();
		Debug.Log(MathModel.GetCaptainValue(p));
	}
	/// <summary>
	/// ����Ͷ�ʵȼ��ͳ���������һ���������
	/// </summary>
	/// <param name="investment_level">Ͷ�ʵȼ�</param>
	/// <param name="cityName">������</param>
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
	/// ����ָ�������Ľ�Ǯ
	/// </summary>
	/// <param name="value">money's value</param>
	[ConsoleMethod("cash", "Add money.")]
	public static void cash(float value)
	{
		GlobalVariable.Money += value;
	}
	/// <summary>
	/// ���ծ��
	/// </summary>
	[ConsoleMethod("ClearDebt", "Clear debt.")]
	public static void ClearDebt()
	{
		GlobalVariable.Debt.index =0;
	}
	/// <summary>
	/// ��ʾծ��
	/// </summary>
	[ConsoleMethod("Debt", "Show your debt.")]
	public static void ShowDebt()
	{
		Debug.Log(GlobalVariable.Debt.ToString());
	}
	/// <summary>
	/// ǿ����ʾһ��GameObject����
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
		if (num != 0) Debug.Log("�ҵ�����Ϊ \"" + name + "\" ��GameObject " + num + " ��");
		else Debug.Log("δ�ҵ���Ϊ \"" + name + "\" ��GameObject"); 

	}
}
