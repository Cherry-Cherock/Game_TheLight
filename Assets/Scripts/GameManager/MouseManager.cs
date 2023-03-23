using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : SingletonMono<MouseManager>
{
    Vector3 mousePos;
    public void Init()
    {
        Debug.Log("------初始化鼠标------");
        mousePos = Vector3.zero;
    }
  
}
