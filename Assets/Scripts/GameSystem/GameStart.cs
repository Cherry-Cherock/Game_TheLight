using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : SingletonMono<GameStart>
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);
        
        // Debug.Log("------初始化UI------");
        // UIData.Init();
        
        Debug.Log("---***---初始化脚本---***---");
        //------初始化设置------
        GameSetting.InitSetting();
        
        //------初始化鼠标------
        MouseManager.Instance.Init();
        
        // Debug.Log("------初始化配置------");
        // ConfigMgr.LoadConfig();
        
        //------初始化声音------
        AudioMgr.Instance.Init();
        
        
        
    }

}
