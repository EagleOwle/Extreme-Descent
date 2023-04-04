using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using TMPro;

public partial class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public event Action<PointerType> eventPointer;
    [SerializeField] private TextMeshProUGUI text;

    private void OnEnable()
    {
        SetTextBold(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        eventPointer?.Invoke(PointerType.Down);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventPointer?.Invoke(PointerType.Enter);
        SetTextBold(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventPointer?.Invoke(PointerType.Exit);
        SetTextBold(false);
    }

    private void SetTextBold(bool value)
    {
        if (text == null)
        {
            Debug.LogWarning("Text is Null");
            return;
        }

        if(value == true)
        {
            text.fontStyle = FontStyles.Bold;
        }
        else
        {
            text.fontStyle = FontStyles.Normal;
        }

    }

}
