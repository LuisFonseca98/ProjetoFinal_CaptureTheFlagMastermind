using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EventTriggers : EventTrigger
{

    public override void OnPointerEnter(PointerEventData data)
    {
        AudioManager.instance.PlayMouseOverSound();
    }

    public override void OnSelect(BaseEventData data)
    {
        AudioManager.instance.PlayClickSound();

    }



}
