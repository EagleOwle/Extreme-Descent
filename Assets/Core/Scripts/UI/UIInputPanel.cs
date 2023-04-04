using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputPanel : MonoBehaviour
{
    [SerializeField] private UIButtonPointerHandler rightButton, leftButton, upButton, downButton;

    public Vector2 ButtonValue => buttonValue;
    private Vector2 buttonValue;

    private void Start()
    {
        rightButton.eventPointer += OnButtonRight;
        leftButton.eventPointer += OnButtonLeft;
        upButton.eventPointer += OnButtonUp;
        downButton.eventPointer += OnButtonDown;
    }

    private void Update()
    {
        //if (moveDirection == 0)
        //{
        //    moveDirection = Input.GetAxis("Horizontal");
        //}

        //if (upDirection == 0)
        //{
        //    upDirection = -Input.GetAxis("Vertical");
        //}
    }

    private void OnButtonRight(PointerType type)
    {
        switch (type)
        {
            case PointerType.Down:
                buttonValue += Vector2.right;
                break;
            case PointerType.Enter:
                break;
            case PointerType.Exit:
                break;
            case PointerType.Up:
                buttonValue -= Vector2.right;
                break;
            default:
                break;
        }
        
    }

    private void OnButtonLeft(PointerType type)
    {
        switch (type)
        {
            case PointerType.Down:
                buttonValue += Vector2.left;
                break;
            case PointerType.Enter:
                break;
            case PointerType.Exit:
                break;
            case PointerType.Up:
                buttonValue -= Vector2.left;
                break;
            default:
                break;
        }
    }

    private void OnButtonUp(PointerType type)
    {
        switch (type)
        {
            case PointerType.Down:
                buttonValue += Vector2.up;
                break;
            case PointerType.Enter:
                break;
            case PointerType.Exit:
                break;
            case PointerType.Up:
                buttonValue -= Vector2.up;
                break;
            default:
                break;
        }
    }

    private void OnButtonDown(PointerType type)
    {
        switch (type)
        {
            case PointerType.Down:
                buttonValue += Vector2.down;
                break;
            case PointerType.Enter:
                break;
            case PointerType.Exit:
                break;
            case PointerType.Up:
                buttonValue -= Vector2.down;
                break;
            default:
                break;
        }
    }

}
