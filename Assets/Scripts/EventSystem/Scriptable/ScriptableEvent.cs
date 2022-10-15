using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvent")]
public class ScriptableEvent : ScriptableObject,IEvent
{
    public Action Event { get; set; }
   
    public void CallEvent()
    {
        Event?.Invoke();
    }

}
