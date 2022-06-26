using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FixedJoystick : Joystick
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        Driver.PointerDown = false;
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Driver.PointerDown = true;
        base.OnPointerUp(eventData);
    }
}