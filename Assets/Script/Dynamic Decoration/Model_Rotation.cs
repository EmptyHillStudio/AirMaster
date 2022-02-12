using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Rotation : MonoBehaviour
{
    public GameObject Model;
    public float speed;
    Vector3 vec;
    void Start()
    {
        vec = new Vector3(5,1,-3);
    }
    void Update()
    {
        transform.RotateAround(vec, Vector3.up, speed);
    }
}
