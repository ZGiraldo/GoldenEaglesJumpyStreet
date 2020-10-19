using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft : MonoBehaviour
{
    [SerializeField] float speed = 0;
    // Update is called once per frame
    void Update()
    {
        Move();
        Invoke("DestroyObject", 2f);
    }

    void Move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
