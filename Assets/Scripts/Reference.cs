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
		camera = GameObject.FindGameObjectWithTag("PathCamera").GetComponent<Camera>() as Camera;;
	}
	
	private void OnEnable()
	{
		inputSystem.Enable();
		inputSystem.Game.MapSetTarget.started += SetTarget;
	}


	private void Start()
	{
		GameObject player = GameObject.FindWithTag("Player");
		var position = player.transform.position;
		Debug.Log("现在玩家位置："+(27+Mathf.RoundToInt(Mathf.Round(position.x * 10f)/10f/1.5f)) +", "+(27+Mathf.RoundToInt(Mathf.Round(position.z * 10f)/10f/1.5f)));

		if (x == 27 + Mathf.RoundToInt(Mathf.Round(position.x * 10f) / 10f / 1.5f) &&
		    y == 27 + Mathf.RoundToInt(Mathf.Round(position.z * 10f) / 10f / 1.5f))
		{
			GetComponent<MeshRenderer> ().material = startMat;
			MyAStar.instance.grids [x, y].type = GridType.Start;
			MyAStar.instance.openList.Add (MyAStar.instance.grids [x, y]);
			MyAStar.instance.startX = x;
			MyAStar.instance.startY = y;
		}
	}

	public void SetTarget(InputAction.CallbackContext context)
	{
		Debug.Log("按下设置目标。");
		
		_ray = camera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(_ray, out _hit, 1000f))
		{
			if (_hit.transform == transform)
			{
				GetComponent<MeshRenderer> ().material = endMat;
				
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
		Debug.Log("dsddss");
		GetComponent<MeshRenderer> ().material = obstacleMat;
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