using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0;
    [SerializeField] float length = 0;

    Vector3 targetPosition;
    Vector3 startPosition;
    bool isMoving;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (isMoving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                isMoving = false;
                return;
            }
            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovementDirection(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MovementDirection(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MovementDirection(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MovementDirection(Vector3.right);
        }

        /*
      float x = Input.GetAxisRaw("Horizontal");
      float z = Input.GetAxisRaw("Vertical");

      if(x == 1f)
      */
    }

    void MovementDirection(Vector3 direction)
    {
        if (!Physics.Raycast(transform.position, direction, length))
        {
            targetPosition = transform.position + direction;
            startPosition = transform.position;
            isMoving = true;
        }
    }
}
