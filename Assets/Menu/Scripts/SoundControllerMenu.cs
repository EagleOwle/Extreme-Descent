using System.Collections;
using UnityEngine;

public class SoundControllerMenu : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip clipShowMenu;
    [SerializeField] private AudioClip clipHideMenu;
    [SerializeField] private AudioClip clipPointerDown;
    [SerializeField] private AudioClip clipPointerEnter;

    private IMenuEvent currentMenu;

    public void Initialise(IMenuEvent menuEvents)
    {
        currentMenu = menuEvents;
        currentMenu.eventHide += OnEventHideMenu;
        currentMenu.eventOnPointer += EventOnPointer;
        source.PlayOneShot(clipShowMenu);
    }

    private void EventOnPointer(PointerType obj)
    {
        switch (obj)
        {
            case PointerType.Down:
                source.PlayOneShot(clipPointerDown);
                break;
            case PointerType.Enter:
                source.PlayOneShot(clipPointerEnter);
                break;
            case PointerType.Exit:
                break;
            default:
                break;
        }
    }

    private void OnEventHideMenu()
    {
        currentMenu.eventHide -= OnEventHideMenu;
        currentMenu.eventOnPointer -= EventOnPointer;
        source.PlayOneShot(clipHideMenu);
    }

}