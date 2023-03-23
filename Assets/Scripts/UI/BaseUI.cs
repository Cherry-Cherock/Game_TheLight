using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public abstract void Initialize();
    
    public virtual void Hide() => gameObject.SetActive(false);

    public virtual void Show() => gameObject.SetActive(true);
    
    public virtual void DestroyUI() => Destroy(gameObject);
    
    #region 封装常用方法
    /// <summary>
    /// 给UI注册点击事件
    /// </summary>
    /// <param name="nodeName">节点名称</param>
    /// <param name="delHandle">委托：需要注册的方法</param>
    protected void AddPointerClickEvent(string nodeName, EventTriggerListener.VoidDelegate delHandle)
    {
        if (delHandle == null)
        {
            Debug.LogErrorFormat("不允许给{0}组件添加空方法", nodeName);
            return;
        }
        Transform uiObj = UnityHelper.FindTheChildNode(this.gameObject, nodeName);
        //给按钮注册事件方法
        if (uiObj == null)
        {
            Debug.LogErrorFormat("{0}组件为空", nodeName);
            return;
        }
        EventTriggerListener.Get(uiObj.gameObject).onPointerClick = delHandle;
        EventTriggerListener.Get(uiObj.gameObject).onPointerClick += go => { AudioMgr.Instance.PlayClickScound(); };
    }
    
    /// <summary>
    /// 给UI注册按下事件
    /// </summary>
    /// <param name="nodeName">节点名称</param>
    /// <param name="delHandle">委托：需要注册的方法</param>
    protected void AddPointerDownEvent(string nodeName, EventTriggerListener.VoidDelegate delHandle)
    {
        if (delHandle == null)
        {
            Debug.LogErrorFormat("不允许给{0}组件添加空方法", nodeName);
            return;
        }
        GameObject uiObj = UnityHelper.FindTheChildNode(this.gameObject, nodeName).gameObject;
        //给按钮注册事件方法
        if (uiObj != null)
        {
            EventTriggerListener.Get(uiObj).onPointerDown = delHandle;
        }
    }
    
    /// <summary>
    /// 给UI注册抬起事件
    /// </summary>
    /// <param name="nodeName">节点名称</param>
    /// <param name="delHandle">委托：需要注册的方法</param>
    protected void AddPointerUpEvent(string nodeName, EventTriggerListener.VoidDelegate delHandle)
    {
        if (delHandle == null)
        {
            Debug.LogErrorFormat("不允许给{0}组件添加空方法", nodeName);
            return;
        }
        GameObject uiObj = UnityHelper.FindTheChildNode(this.gameObject, nodeName).gameObject;
        //给按钮注册事件方法
        if (uiObj != null)
        {
            EventTriggerListener.Get(uiObj).onPointerUp = delHandle;
        }
    }
    
    /// <summary>
    /// 给UI注册鼠标进入事件
    /// </summary>
    /// <param name="nodeName">节点名称</param>
    /// <param name="delHandle">委托：需要注册的方法</param>
    protected void AddPointerEnterEvent(string nodeName, EventTriggerListener.VoidDelegate delHandle)
    {
        if (delHandle == null)
        {
            Debug.LogErrorFormat("不允许给{0}组件添加空方法", nodeName);
            return;
        }
        GameObject uiObj = UnityHelper.FindTheChildNode(this.gameObject, nodeName).gameObject;
        //给按钮注册事件方法
        if (uiObj != null)
        {
            EventTriggerListener.Get(uiObj).onPointerEnter = delHandle;
        }
    }
    
    /// <summary>
    /// 给UI注册鼠标退出事件
    /// </summary>
    /// <param name="nodeName">节点名称</param>
    /// <param name="delHandle">委托：需要注册的方法</param>
    protected void AddPointerExitEvent(string nodeName, EventTriggerListener.VoidDelegate delHandle)
    {
        if (delHandle == null)
        {
            Debug.LogErrorFormat("不允许给{0}组件添加空方法", nodeName);
            return;
        }
        GameObject uiObj = UnityHelper.FindTheChildNode(this.gameObject, nodeName).gameObject;
        //给按钮注册事件方法
        if (uiObj != null)
        {
            EventTriggerListener.Get(uiObj).onPointerExit = delHandle;
        }
    }
    
    /// <summary>
    /// 给UI注册拖动事件
    /// </summary>
    /// <param name="nodeName">节点名称</param>
    /// <param name="delHandle">委托：需要注册的方法</param>
    protected void AddDragEvent(string nodeName, EventTriggerListener.VoidDelegate delHandle)
    {
        if (delHandle == null)
        {
            Debug.LogErrorFormat("不允许给{0}组件添加空方法", nodeName);
            return;
        }
        GameObject uiObj = UnityHelper.FindTheChildNode(this.gameObject, nodeName).gameObject;
        //给按钮注册事件方法
        if (uiObj != null)
        {
            EventTriggerListener.Get(uiObj).onDrag = delHandle;
        }
    }
    
    /// <summary>
    /// 给UI注册结束拖动事件
    /// </summary>
    /// <param name="nodeName">节点名称</param>
    /// <param name="delHandle">委托：需要注册的方法</param>
    protected void AddEndDragEvent(string nodeName, EventTriggerListener.VoidDelegate delHandle)
    {
        if (delHandle == null)
        {
            Debug.LogErrorFormat("不允许给{0}组件添加空方法", nodeName);
            return;
        }
        GameObject uiObj = UnityHelper.FindTheChildNode(this.gameObject, nodeName).gameObject;
        //给按钮注册事件方法
        if (uiObj != null)
        {
            EventTriggerListener.Get(uiObj).onEndDrag = delHandle;
        }
    }
    
    // /// <summary>
    // /// 关闭当前UI窗体
    // /// </summary>
    // protected void CloseSelf()
    // {
    //     UIManager.Instance.CloseUI(this);
    // }
    
    #endregion
    
}
