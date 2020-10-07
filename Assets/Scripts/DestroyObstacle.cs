using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
