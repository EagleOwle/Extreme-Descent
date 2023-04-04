using System;

public interface IMenuEvent
{
    event Action eventHide;
    event Action<IMenuEvent> eventShow;
    event Action<PointerType> eventOnPointer;
}