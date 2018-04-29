using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerDerived : EventTrigger {

    public delegate void VoidDelegate(GameObject go);

    //  单击
    public VoidDelegate onClick; 
    
    //  双击
    public VoidDelegate onDoubleClick;

    //  光标进入
    public VoidDelegate onPointerEnter;
    
    //  光标移出
    public VoidDelegate onPointerExit;
    
    //  按下
    public VoidDelegate onPressDown;
    
    //  抬起
    public VoidDelegate onPressUp;

    static public EventTriggerDerived Get(GameObject go)
    {
        EventTriggerDerived eventObj = go.GetComponent<EventTriggerDerived>();

        if(eventObj == null)
        {
            eventObj = go.AddComponent<EventTriggerDerived>();
        }

        return eventObj;
    }

    static public EventTriggerDerived Get(Transform tf)
    {
        EventTriggerDerived eventObj = tf.GetComponent<EventTriggerDerived>();

        if (eventObj == null)
        {
            eventObj = tf.gameObject.AddComponent<EventTriggerDerived>();
        }

        return eventObj;
    }
}
