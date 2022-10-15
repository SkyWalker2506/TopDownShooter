using System;

public interface IEvent
{
    public Action Event { get; set; }
    void CallEvent();

}

public interface IEvent<T> 
{
    public Action<T> Event { get; set; }
    void CallEvent(T value);

}