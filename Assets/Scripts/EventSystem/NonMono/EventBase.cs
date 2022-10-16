using System;

namespace EventSystem
{
    public class EventBase : IEvent
    {
        public Action Event { get; set; }

        public void CallEvent()
        {
            Event?.Invoke();
        }
    }

    public class EventBase<T> : IEvent<T>
    {
        public Action<T> Event { get; set; }
        public void CallEvent(T value)
        {
            Event?.Invoke(value);
        }
    }
}