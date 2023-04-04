using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyboardToUIButton : MonoBehaviour
{
    [SerializeField] private UIButtonPointerHandler rightButton, leftButton, upButton, downButton;
    [SerializeField] EventSystem eventSystem;

    private void Update()
    {
        PointerEventData eventData = new PointerEventData(eventSystem);

        if (Input.GetKeyDown(KeyCode.W))
        {
           upButton.OnPointerDown(eventData);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            upButton.OnPointerUp(eventData);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            downButton.OnPointerDown(eventData);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            downButton.OnPointerUp(eventData);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            leftButton.OnPointerDown(eventData);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            leftButton.OnPointerUp(eventData);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            rightButton.OnPointerDown(eventData);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rightButton.OnPointerUp(eventData);
        }
    }

}
