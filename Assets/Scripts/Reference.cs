using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
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

//判断当前格子的类型
	void OnTriggerEnter (Collider other)
	{
		if (other.name == "Start") {
			GetComponent<MeshRenderer> ().material = startMat;
			MyAStar.instance.grids [x, y].type = GridType.Start;
			MyAStar.instance.openList.Add (MyAStar.instance.grids [x, y]);
			MyAStar.instance.startX = x;
			MyAStar.instance.startY = y;
		} else if (other.name == "End") {
			GetComponent<MeshRenderer> ().material = endMat;
			Debug.Log("X: "+x+"     "+"Y: "+y);
			MyAStar.instance.grids [x, y].type = GridType.End;
			MyAStar.instance.targetX = x;
			MyAStar.instance.targetY = y;
			startPath?.Invoke();
		} else if (other.name == "Obs") {
			GetComponent<MeshRenderer> ().material = obstacleMat;
			MyAStar.instance.grids [x, y].type = GridType.Obstacle;
		}
	}

}