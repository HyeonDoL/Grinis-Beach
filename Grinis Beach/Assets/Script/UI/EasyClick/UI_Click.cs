using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(EventTrigger))]
public abstract class UI_Click : MonoBehaviour
{
    public abstract void OnClick(BaseEventData bed);

    public virtual void SetTrigger(UnityAction<BaseEventData> call)
    {
        EventTrigger.Entry MyEntry = new EventTrigger.Entry();
        MyEntry.eventID = EventTriggerType.PointerClick;
        MyEntry.callback.AddListener(call);
        this.GetComponent<EventTrigger>().triggers.Add(MyEntry);
    }
}