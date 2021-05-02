using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelorRotate : MonoBehaviour
{
    float _speed;

   void Start()
    {
        _speed = 100;
    }

    void Update()
    {
        transform.eulerAngles += new Vector3(0f,  0f, _speed * Time.deltaTime);
    }
}
