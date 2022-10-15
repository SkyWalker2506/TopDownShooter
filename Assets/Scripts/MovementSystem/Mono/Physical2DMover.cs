using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Physical2DMover : MonoBehaviour, ICanMove2D
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveBackward(float value)
    {
        Move(Vector3.back * value);
    }

    public void MoveForward(float value)
    {
        Move(Vector3.forward * value);
    }

    public void MoveLeft(float value)
    {
        Move(Vector3.left * value);
    }

    public void MoveRight(float value)
    {
        Move(Vector3.right * value);
    }

    void Move(Vector3 moveVector)
    {
        rb.MovePosition(rb.position + moveVector* Time.deltaTime);
        rb.velocity = Vector3.zero;

        float turnSpeed = 10;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveVector, turnSpeed *Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
