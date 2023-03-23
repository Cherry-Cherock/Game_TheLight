using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 不继承MonoBehaviour的单例
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T : new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
/// <summary>
/// 继承MonoBehaviour的单例
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
{
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find("MainObject");
                if (go == null)
                {
                    go = new GameObject("MainObject");
                    GameObject.DontDestroyOnLoad(go);
                }
                else
                {
                    instance = go.GetComponent<T>();
                }

                if (instance == null)
                {
                    instance = go.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}

