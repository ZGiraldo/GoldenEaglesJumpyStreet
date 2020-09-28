using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCamera : MonoBehaviour
{
    [SerializeField] Transform target = null;

    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset = new Vector3();

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
