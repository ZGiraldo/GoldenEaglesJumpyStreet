using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft : MonoBehaviour
{
    [SerializeField] float speed = 0;
    // Update is called once per frame

    void Start()
    {
        Destroy(gameObject,2f);
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
    }
}
