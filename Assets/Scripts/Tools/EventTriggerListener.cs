using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerListener : EventTrigger
    {
        public delegate void VoidDelegate(GameObject go);
        public VoidDelegate onPointerDown;
        public VoidDelegate onPointerClick;
        public VoidDelegate onPointerUp;
        public VoidDelegate onPointerEnter;
        public VoidDelegate onPointerExit;
        public VoidDelegate onBeginDrag;
        public VoidDelegate onDrag;
        public VoidDelegate onEndDrag;
        public VoidDelegate onSelect;

        /// <summary>
        /// 得到“监听器”组件
        /// </summary>
        /// <param name="go">监听的游戏对象</param>
        /// <returns>
        /// 监听器
        /// </returns>
        public static EventTriggerListener Get(GameObject go)
        {
            EventTriggerListener lister = go.GetComponent<EventTriggerListener>();
            if (lister == null)
            {
                lister = go.AddComponent<EventTriggerListener>();
            }
            return lister;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (onPointerDown != null)
            {
                onPointerDown(gameObject);
            }
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (onPointerClick != null)
            {
                onPointerClick(gameObject);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (onPointerUp != null)
            {
                onPointerUp(gameObject);
            }
        }


        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (onPointerEnter != null)
            {
                onPointerEnter(gameObject);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (onPointerExit != null)
            {
                onPointerExit(gameObject);
            }
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (onBeginDrag != null)
            {
                onBeginDrag(gameObject);
            }
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (onDrag != null)
            {
                onDrag(gameObject);
            }
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (onEndDrag != null)
            {
                onEndDrag(gameObject);
            }
        }

        public override void OnSelect(BaseEventData eventData)
        {
            if (onSelect != null)
            {
                onSelect(gameObject);
            }
        }
    }
