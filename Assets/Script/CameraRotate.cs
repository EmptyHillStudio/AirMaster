using UnityEngine;
using System;

public class CameraRotate : MonoBehaviour
{
    // Update is called once per frame
   
    void Update()

    {
        var Sphere = GameObject.Find("Sphere");
        transform.RotateAround(Sphere.transform.position, Vector3.up,0); //�����Χ��Ŀ����ת
        var mouse_x = Input.GetAxis("Mouse X");//��ȡ���X���ƶ�
        var mouse_y = -Input.GetAxis("Mouse Y");//��ȡ���Y���ƶ�
        Debug.Log(mouse_y);
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(Vector3.left * (mouse_x * 12f) * Time.deltaTime);
            transform.Translate(Vector3.up * (mouse_y * 12f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.RotateAround(Sphere.transform.position, Vector3.up, mouse_x * 2);
            transform.RotateAround(Sphere.transform.position, transform.right, mouse_y * 2);
        }


    }


}
