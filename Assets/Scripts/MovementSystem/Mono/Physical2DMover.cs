using UnityEngine;

namespace MovementSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Physical2DMover : MonoBehaviour, ICanMove2D
    {
        Rigidbody rb;

        Vector3 moveVector = Vector3.zero;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void LateUpdate()
        {
            if (moveVector != Vector3.zero)
            {
                Move(moveVector);
                moveVector = Vector3.zero;
            }
        }

        public void MoveHorizontal(float value)
        {
            moveVector.x = value;
        }
        public void MoveDepth(float value)
        {
            moveVector.z = value;
        }

        void Move(Vector3 moveVector)
        {
            rb.MovePosition(rb.position + moveVector* Time.deltaTime);
            rb.velocity = Vector3.zero;

            float turnSpeed = 50;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveVector, turnSpeed *Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}