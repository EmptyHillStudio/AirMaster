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
        transform.RotateAround(Sphere.transform.position, Vector3.up,0); //�����Χ��Ŀ����ת
        var mouse_x = -Input.GetAxis("Mouse X");//��ȡ���X���ƶ�
        var mouse_y = -Input.GetAxis("Mouse Y");//��ȡ���Y���ƶ�
        float f = 0;
        if (transform.localEulerAngles.x > 180)//�ٶ����ƣ���ֹͻ��275��85���ӽǽ��ޣ������ֵ������Ҫ�Ż������������ֵ���������ֵ����ʽ��
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
