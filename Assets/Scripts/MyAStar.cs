﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class MyAStar : MonoBehaviour
{
	//显示地图 按键监听
	private PlayerControl inputSystem;
	public delegate void MClick(); 
	public static event MClick startPoint;

	// public static event MClick startLoading;
	//切换相机
	public Camera mainCamera;
	public Camera pathFindCamera;
	public Camera uiCamera;
	
	/// <summary>
	/// 单例脚本
	/// </summary>
	public static MyAStar instance;

	// private GameManager gm;
	public Light normalLight;
	public Light mapLight;
	
	//参考物体预设体
	public GameObject reference;
	//格子数组
	public Grid[,] grids;
	//格子数组对应的参考物（方块）对象
	public GameObject[,] objs;
	//开启列表
	public ArrayList openList;
	//关闭列表
	public ArrayList closeList;
	//目标点坐标
	public int targetX;
	public int targetY;
	//起始点坐标
	public int startX;
	public int startY;

	//格子行列数
	private int row;
	private int colomn;
	//结果栈
	private Stack<string> parentList;
	//历史栈
	private Stack<string> historyList;
	//基础物体
	private Transform plane;
	private Transform start;
	private Transform end;
	private Transform obstacle;
	void Awake ()
	{
		inputSystem = InputManager.inputActions;
		// gm = gameObject.GetComponent<GameManager>();
		historyList = new Stack<string> ();
	}

	private void OnEnable()
	{
		inputSystem.Enable();
		inputSystem.Game.Map.started += ShowMap;
		// inputSystem.Map.SetTarget.started += SetTarget;
		Reference.startPath += StartFindingPath;
	}
	
	//初始化值
	public void initPoints()
	{
		instance = this;
		plane = GameObject.Find ("Ground").transform;
		// start = GameObject.Find ("Start").transform;
		// end = GameObject.Find ("End").transform;
		// obstacle = GameObject.Find ("Obs").transform;
		parentList = new Stack<string> ();
		openList = new ArrayList ();
		closeList = new ArrayList ();
		CleanResult();
	}
	
	//初始化地图
	public void InitMap()
	{
		//计算行列数
		int x = (int)(plane.localScale.x * 7);
		int y = (int)(plane.localScale.z * 7);
		row = x;
		colomn = y;
		grids = new Grid[x, y];
		objs = new GameObject[x, y];
		//起始坐标
		Vector3 startPos = 
			new Vector3 (plane.localScale.x * -5, 0, plane.localScale.z * -5);
		//生成参考物体（Cube）
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				grids [i, j] = new Grid (i, j);
				GameObject item = (GameObject)Instantiate (reference, 
					new Vector3 (i * 1.5f, 1, j * 1.5f) + startPos, 
					Quaternion.identity);
				item.transform.GetChild (0).GetComponent<Reference> ().x = i;
				item.transform.GetChild (0).GetComponent<Reference> ().y = j;
				objs [i, j] = item;
			}
		}
	}



	public void ShowMap(InputAction.CallbackContext context)
	{
		// startLoading.Invoke();
		startPoint.Invoke();
		// gm.ToggleMap();
		pathFindCamera.enabled = true;
		uiCamera.enabled = !pathFindCamera.enabled;
		mainCamera.enabled = !pathFindCamera.enabled;
		
		initPoints();
		InitMap();
		mapLight.enabled = true;
		normalLight.enabled = !mapLight.enabled;
		// Time.timeScale = 0.0f;
	}

	public void StartFindingPath()
	{
		initPoints();
		if (targetX != 0 || targetY != 0)
		{
			StartCoroutine (Count ());
			StartCoroutine (ShowResult ());
		}
	}
	

	/// <summary>
	/// A*计算
	/// </summary>
	IEnumerator Count ()
	{
		//等待前面操作完成
		yield return new WaitForSeconds (0.1f);
		//添加起始点
		openList.Add (grids [startX, startY]);
		//声明当前格子变量，并赋初值
		Grid currentGrid = openList [0] as Grid;
		//循环遍历路径最小F的点
		while (openList.Count > 0 && currentGrid.type != GridType.End) {
			//获取此时最小F点
			currentGrid = openList [0] as Grid;
			//如果当前点就是目标
			if (currentGrid.type == GridType.End) {
				Debug.Log ("Find");
				//生成结果
				GenerateResult (currentGrid);
			}
			//上下左右，左上左下，右上右下，遍历
			for (int i = -1; i <= 1; i++) {
				for (int j = -1; j <= 1; j++) {
					if (i != 0 || j != 0) {
						//计算坐标
						int x = currentGrid.x + i;
						int y = currentGrid.y + j;
						//如果未超出所有格子范围，不是障碍物，不是重复点
						if (x >= 0 && y >= 0 && x < row && y < colomn
						    && grids [x, y].type != GridType.Obstacle
						    && !closeList.Contains (grids [x, y])) {
							//计算G值
							int g = currentGrid.g + (int)(Mathf.Sqrt ((Mathf.Abs (i) + Mathf.Abs (j))) * 10);
							//与原G值对照
							if (grids [x, y].g == 0 || grids [x, y].g > g) {
								//更新G值
								grids [x, y].g = g;
								//更新父格子
								grids [x, y].parent = currentGrid;
							}
							//计算H值
							grids [x, y].h = Manhattan (x, y);
							//计算F值
							grids [x, y].f = grids [x, y].g + grids [x, y].h;
							//如果未添加到开启列表
							if (!openList.Contains (grids [x, y])) {
								//添加
								openList.Add (grids [x, y]);
							}
							//重新排序
							openList.Sort ();
						}
					}
				}
			}
			//完成遍历添加该点到关闭列表
			closeList.Add (currentGrid);
			//从开启列表中移除
			openList.Remove (currentGrid);
			//如果开启列表空，未能找到路径
			if (openList.Count == 0) {
				Debug.Log ("Can not Find");
			}
		}


	}

	/// <summary>
	/// 生成结果
	/// </summary>
	/// <param name="currentGrid">Current grid.</param>
	void GenerateResult (Grid currentGrid)
	{
		//如果当前格子有父格子
		if (currentGrid.parent != null) {
			//添加到父对象栈（即结果栈）
			parentList.Push (currentGrid.x + "|" + currentGrid.y);
			historyList.Push(currentGrid.x + "|" + currentGrid.y);
			//递归获取
			GenerateResult (currentGrid.parent);
		}
	}

	/// <summary>
	/// 显示结果
	/// </summary>
	/// <returns>The result.</returns>
	IEnumerator ShowResult ()
	{
		//等待前面计算完成
		yield return new WaitForSeconds (0.2f);
		//展示结果
		while (parentList.Count != 0)
		{
			//出栈
			string str = parentList.Pop();
			//等0.4秒
			yield return new WaitForSeconds (0.1f);
			//拆分获取坐标
			string[] xy = str.Split (new char[]{ '|' });
			int x = int.Parse (xy [0]);
			int y = int.Parse (xy [1]);
			//以颜色方式绘制路径
			objs [x, y].transform.GetChild (0).GetComponent<MeshRenderer> ().material.color
			= new Color (0, 0, 0, 1);
		}
	}
	
	public void CleanResult ()
	{
		//清除结果
		while (historyList.Count != 0) {
			//出栈
			string str = historyList.Pop();
			//拆分获取坐标
			string[] xy = str.Split (new char[]{ '|' });
			int x = int.Parse (xy [0]);
			int y = int.Parse (xy [1]);
			//以颜色方式绘制路径
			objs [x, y].transform.GetChild (0).GetComponent<MeshRenderer> ().material.color
				= new Color (255, 255, 255, 1);
		}
	}

	/// <summary>
	/// 曼哈顿方式计算H值
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	int Manhattan (int x, int y)
	{
		return (int)(Mathf.Abs (targetX - x) + Mathf.Abs (targetY - y)) * 10;
	}
	
}
