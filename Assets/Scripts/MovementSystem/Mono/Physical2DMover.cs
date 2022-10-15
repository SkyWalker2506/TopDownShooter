using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Physical2DMover : MonoBehaviour, ICanMove2D
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveHorizontal(float value)
    {
        Move(Vector3.right * value);
    }
    public void MoveDepth(float value)
    {
        Move(Vector3.forward * value);
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
