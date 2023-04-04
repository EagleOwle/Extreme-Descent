using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class UIButtonPointerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action<PointerType> eventPointer;

    public void OnPointerDown(PointerEventData eventData)
    {
        eventPointer?.Invoke(PointerType.Down);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        eventPointer?.Invoke(PointerType.Up);
    }

}
