using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 5;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, -1, 0).normalized;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
