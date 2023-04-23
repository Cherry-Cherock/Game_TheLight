using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.UI;

public class Reference : MonoBehaviour
{
	//颜色材质区分
	public Material startMat;
	public Material endMat;
	public Material obstacleMat;

	//当前格子坐标
	public int x;
	public int y;
	public delegate void CallNumber(); 
	public static event CallNumber startPath;

	//物体点击
	private Camera camera;
	private Ray _ray;
	private RaycastHit _hit;
	private PlayerControl inputSystem;
	
	void Awake ()
	{
		inputSystem = InputManager.inputActions;
		camera = Camera.current;
	}
	
	private void OnEnable()
	{
		inputSystem.Enable();
		inputSystem.Game.MapSetTarget.started += SetTarget;
	}

	
	public void SetTarget(InputAction.CallbackContext context)
	{
		_ray = camera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(_ray, out _hit, 1000f))
		{
			if (_hit.transform == transform)
			{
				GetComponent<MeshRenderer> ().material = endMat;
				Debug.Log("设置目标点: "+"("+x+", "+y+")"+"  使用的相机: "+camera.name);
				MyAStar.instance.grids [x, y].type = GridType.End;
				MyAStar.instance.targetX = x;
				MyAStar.instance.targetY = y;
				startPath.Invoke();
			}
		}
	}


//判断当前格子的类型
	void OnTriggerEnter (Collider other)
	{
		if (other.name == "Start") {
			GetComponent<MeshRenderer> ().material = startMat;
			MyAStar.instance.grids [x, y].type = GridType.Start;
			MyAStar.instance.openList.Add (MyAStar.instance.grids [x, y]);
			MyAStar.instance.startX = x;
			MyAStar.instance.startY = y;
		} else if (other.name == "Obs") {
			GetComponent<MeshRenderer> ().material = obstacleMat;
			MyAStar.instance.grids [x, y].type = GridType.Obstacle;
		}
	}


	public void Destroy()
	{
		
	}

}