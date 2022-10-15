using System;

public class EventBase : IEvent
{
    public Action Event { get; set; }

    public void CallEvent()
    {
        throw new NotImplementedException();
    }
}