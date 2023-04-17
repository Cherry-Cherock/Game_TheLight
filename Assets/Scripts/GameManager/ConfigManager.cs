using System.Collections;
using System.Collections.Generic;
using GameConfig;
using Newtonsoft.Json;
using UnityEngine;

public static class ConfigManager
{
    public static Dictionary<int, PlayerConfig> PlayerConfigList { get; } = new Dictionary<int, PlayerConfig>();
    
    
    public static bool LoadConfig()
    {
        LoadConfig(PlayerConfigList, "Assets/test/test.txt");

        return true;
    }
    
    private static void LoadConfig<T>(Dictionary<int, T> dic, string path) where T : class
    {
        if (dic != null && dic.Count > 0)
        {
            Debug.LogErrorFormat("注意!!!配置 \"{0}\" 被重复加载", typeof(T));
            return;
        }

        try
        {
            TextAsset json = ResLoad.Load<TextAsset>(path);
            Dictionary<int, T> tempDic = JsonConvert.DeserializeObject<Dictionary<int, T>>(json.text);
            foreach (var item in tempDic)
            {
                dic.Add(item.Key, item.Value);
            }

            Debug.LogFormat(path + " 配置 \"{0}\" 有 {1} 个数据", typeof(T), dic.Count);
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
            throw ex;
        }
    }
    
}
