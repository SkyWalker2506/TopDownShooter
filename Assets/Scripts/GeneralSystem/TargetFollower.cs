using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        if (target)
            Follow();
    }

    void Follow()
    {
        transform.position = target.position + offset;
    }
}