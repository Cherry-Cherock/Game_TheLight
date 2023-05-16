using UnityEngine;

public class FloatPoint : MonoBehaviour
{
    public float destoryTime;
    void Start()
    {
        Destroy(gameObject,destoryTime);
    }

}
