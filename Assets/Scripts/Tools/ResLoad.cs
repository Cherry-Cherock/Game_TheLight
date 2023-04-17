using UnityEditor;
using UnityEngine;

public class ResLoad
{
    public static T Load<T>(string path) where T : UnityEngine.Object
    {
        T ob = null;
#if UNITY_EDITOR
        ob = AssetDatabase.LoadAssetAtPath<T>(path);
#else
        path = path.Remove(path.LastIndexOf('.')).Replace("Assets/","").Replace("Resources/", "");
        ob = Resources.Load<T>(path);
#endif
        if (ob == null)
        {
            Debug.LogError(path + " 资源为NULL");
        }
        return ob;
    }

    public static ResourceRequest LoadAsync<T>(string path) where T : UnityEngine.Object
    {
        return Resources.LoadAsync<T>(path);
    }
    public static T[] LoadAll<T>(string path) where T : UnityEngine.Object
    {
        path = path.Replace("Assets/Resources/", "");
        return Resources.LoadAll<T>(path);
    }

}
