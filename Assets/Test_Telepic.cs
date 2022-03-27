using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Test_Telepic : MonoBehaviour
{
	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		PlaneCaptain.GetRandomPlaneCaptain(5, GlobalVariable.DefaultManager.cities_manager.getCityByName("Beijing"));
	}
}
