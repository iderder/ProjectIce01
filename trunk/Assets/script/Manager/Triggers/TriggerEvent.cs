using UnityEngine;
using System;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

    public Loop.EventType eventType = Loop.EventType.None;  // 当前触发事件类型
    public Loop.EventType conditionEventType1 = Loop.EventType.None;  // 条件事件类型
    public Loop.EventType conditionEventType2 = Loop.EventType.None;
    public Loop.EventType conditionEventType3 = Loop.EventType.None;
    public Loop.EventType conditionEventType4 = Loop.EventType.None;
    public Loop.EventType conditionEventType5 = Loop.EventType.None;
    
    //public bool isFiredOnce;  // 是否曾经已出发
    //public bool isValid;  // 是否仍然有效
    //public uint firedTimes;   // 已触发次数
    public float delayPeriod;     // 延迟处理时间(s)
    public float expiredPeriod;     // 失效时间(s)

    void Start() {

        if (eventType == Loop.EventType.None)
            return;

        // 将条件事件加入判断列表
        if (conditionEventType1 != Loop.EventType.None)
        {
            Loop.EventManager.EventArray[(int)eventType].AddPrevEvents((uint)conditionEventType1);
        }

        if (conditionEventType2 != Loop.EventType.None)
        {
            Loop.EventManager.EventArray[(int)eventType].AddPrevEvents((uint)conditionEventType2);
        }

        if (conditionEventType3 != Loop.EventType.None)
        {
            Loop.EventManager.EventArray[(int)eventType].AddPrevEvents((uint)conditionEventType3);
        }

        if (conditionEventType4 != Loop.EventType.None)
        {
            Loop.EventManager.EventArray[(int)eventType].AddPrevEvents((uint)conditionEventType4);
        }

        if (conditionEventType5 != Loop.EventType.None)
        {
            Loop.EventManager.EventArray[(int)eventType].AddPrevEvents((uint)conditionEventType5);
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("-- Func : OnTriggerEnter --");
        
        if (other.gameObject.CompareTag("Player")) {

            if (eventType == Loop.EventType.None)
                return;

            // 测试条件
            if (Loop.EventManager.EventArray[(int)eventType].IsAllPrevEventsValid()) {
                // do something
                Loop.EventManager.FireEvent(Loop.EventManager.EventArray[(int)eventType]);
                Loop.EventManager.EventArray[(int)eventType].DelayPeriod = delayPeriod;
                Loop.EventManager.EventArray[(int)eventType].ExpiredPeriod = expiredPeriod;
            }

        }
    }
}
