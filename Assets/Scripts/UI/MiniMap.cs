using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;

    private Camera miniMapCamera;
    //zoom
    private float maximum = 20;
    private float minmum = 3;
    private float view_value=10f;

    private void Start()
    {
        miniMapCamera = transform.GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
    private void Update()
    {
        //滚轮实现摄像机视角的缩进和放远 
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            miniMapCamera.orthographicSize = Mathf.Clamp(miniMapCamera.orthographicSize, minmum, maximum);
            miniMapCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * view_value;
        }
    }
}
