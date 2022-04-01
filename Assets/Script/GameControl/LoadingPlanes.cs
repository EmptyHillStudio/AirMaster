using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingPlanes : MonoBehaviour
{
    public static int Planes_num;
    public GameObject CopiedGameObject;

    //刚开始时加载所有飞机并隐藏起来，显示初始文本
    void Start()
    {
        Planes_num = 0;
        PlanesManager pManager = GlobalVariable.DefaultManager.planesManager;
        foreach (Plane p in pManager.GetPlanes())
        {
            GameObject go = Instantiate(CopiedGameObject);
            BoardBindedInPlaneBuying pbb = go.GetComponent<BoardBindedInPlaneBuying>();
            go.transform.SetParent(CopiedGameObject.transform.parent);
            pbb.BindedPlane = p;
            go.name = p.series + "-" + p.sub;
            CompaniesShowing.PlanesBoard.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
