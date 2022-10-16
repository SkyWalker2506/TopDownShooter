using EventSystem;
using UnityEngine;

namespace CharacterSystem
{
    public abstract class EnemyAI : MonoBehaviour, IEnemyAI
    {
        public IEvent<float> OnHorizontalMovementInput { get; set; } = new EventBase<float>();
        public IEvent<float> OnDepthMovementInput { get; set; } = new EventBase<float>();
        public IEvent AttackAction { get; set; } = new EventBase();
        public IEvent AttackStoppedEvent { get; set; } = new EventBase();
        public IEvent SwapEvent { get; set; } = new EventBase();
    }
}