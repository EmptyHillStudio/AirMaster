using UnityEngine;
using System;

public class CameraRotate : MonoBehaviour
{
    // Update is called once per frame
    private Vector3 pastVec;
    private Vector3 pastPosi;
    void Start()
    {
        this.pastVec = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        this.pastPosi = transform.position;
    }

    void Update()
    {
        var Sphere = GameObject.Find("Sphere");
        transform.RotateAround(Sphere.transform.position, Vector3.up,0); //摄像机围绕目标旋转
        var mouse_x = -Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        float f = 0;
        if (transform.localEulerAngles.x > 180)//速度限制，防止突破275和85的视角界限，该最大值函数需要优化，具体采用数值分析构造插值多项式。
        {
            f = transform.localEulerAngles.x - 270;
        }
        else
        {
            f = 90 - transform.localEulerAngles.x;
        }
        if(Math.Abs(mouse_y) > f/2)
        {
            mouse_y = 2 * Math.Sign(mouse_y);
        }
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(Vector3.left * (mouse_x * 12f) * Time.deltaTime);
            transform.Translate(Vector3.up * (mouse_y * 12f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (transform.localEulerAngles.x > 275 || transform.localEulerAngles.x < 85)
            {
                transform.RotateAround(Sphere.transform.position, transform.right, mouse_y * 2);
            }
            else if (transform.localEulerAngles.x <= 275 && transform.localEulerAngles.x > 180 && mouse_y < 0)
            {
                transform.RotateAround(Sphere.transform.position, transform.right, mouse_y * 2);
            }
            else if (transform.localEulerAngles.x >= 85 && transform.localEulerAngles.x<180 && mouse_y > 0)
            {
                transform.RotateAround(Sphere.transform.position, transform.right, mouse_y * 2);
            }
            transform.RotateAround(Sphere.transform.position, Vector3.up, mouse_x * 2);
        }
    }


}
