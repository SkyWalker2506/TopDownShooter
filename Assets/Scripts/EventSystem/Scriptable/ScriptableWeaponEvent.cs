using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableWeaponEvent")]
public class ScriptableWeaponEvent : ScriptableObject, IHaveWeaponInput
{
    public IEvent AttackAction { get; set; } = new EventBase();
    public IEvent AttackStoppedEvent { get; set; } = new EventBase();
    public IEvent SwapEvent { get; set; } = new EventBase();

    public void CallAttackEvent() => AttackAction.CallEvent();
    public void CallAttackStoppedEvent() => AttackStoppedEvent.CallEvent();
    public void CallSwapEvent() => SwapEvent.CallEvent();

}