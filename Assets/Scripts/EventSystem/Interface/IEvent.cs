using System;

public interface IEvent
{
    public Action Event { get; set; }
    void CallEvent();

}