 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    //滚轮实现镜头缩进和拉远的范围
    private float sensitivetyMouseWheel = 10f;
    private float maximum = 100;
    private float minmum = 30;
    private float view_value=20f;
    private Vector3 offset;
    private PlayerControl inputSystem;
    
    private void Awake()
    {
        inputSystem = new PlayerControl();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
    }

    void Start()
    {
        offset = target.position - transform.position;
    }

    private void Update()
    {
        // //滚轮实现摄像机视角的缩进和放远 
        // if (Input.GetAxis("Mouse ScrollWheel") != 0)
        // {
        //     Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minmum, maximum);
        //     Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * view_value;
        // }
    }

    void LateUpdate()
    {
        transform.position = target.position - offset;
    }
}
