using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    // Update is called once per frame
   
    void Update()

    {
        var Sphere = GameObject.Find("Sphere");
        transform.RotateAround(Sphere.transform.position, Vector3.up, 0); //�����Χ��Ŀ����ת
        var mouse_x = Input.GetAxis("Mouse X");//��ȡ���X���ƶ�
        var mouse_y = -Input.GetAxis("Mouse Y");//��ȡ���Y���ƶ�
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(Vector3.left * (mouse_x * -10f) * Time.deltaTime);
            transform.Translate(Vector3.up * (mouse_y * -10f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.RotateAround(Sphere.transform.position, Vector3.up, mouse_x * 5);
            transform.RotateAround(Sphere.transform.position, transform.right, mouse_y * 5);
        }


    }


}
