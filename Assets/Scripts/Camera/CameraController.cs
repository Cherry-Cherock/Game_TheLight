﻿ using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.InputSystem;

 public class CameraController : MonoBehaviour
{
    public Transform target;
    //自由视角
    private float mX = 0.0f;
    private float mY = 0.0f;

    private float MinLimitY=5;
    private float MaxLimitY=80;
    
    private float MinLimitX=-50;
    private float MaxLimitX=50;

    private Quaternion mRotation;
    //自由视角
    private bool freeView = false;
    
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
        inputSystem.Camera.FreeView.performed += EnableFreeView;
    }

    private void OnDisable()
    {
        inputSystem.Camera.FreeView.performed -= EnableFreeView;
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
        if (freeView)
        {
            mX += Input.GetAxis("Mouse X") * sensitivetyMouseWheel * 0.02f;
            mY -= Input.GetAxis("Mouse Y") * sensitivetyMouseWheel * 0.02f;
            mX = ClampAngle(mX, MinLimitX, MaxLimitX);
            mY = ClampAngle(mY, MinLimitY, MaxLimitY);
            mRotation = Quaternion.Euler(mY,mX,0);
        }
        else
        {
            mRotation = Quaternion.Euler(23,0,0); 
            
        }
        transform.position = target.position - offset;
        transform.rotation = Quaternion.Slerp(transform.rotation,mRotation,Time.deltaTime*2.5f);
    }

    private void EnableFreeView(InputAction.CallbackContext ctx)
    {
        mX = 0.0f;
        mY = 0.0f;
        freeView = !freeView;
    }
    
    

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
