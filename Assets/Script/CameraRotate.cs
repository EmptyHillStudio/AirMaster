using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    // Update is called once per frame
   
    void Update()

    {
        var Sphere = GameObject.Find("Sphere");
        transform.RotateAround(Sphere.transform.position, Vector3.up, 0); //摄像机围绕目标旋转
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
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
