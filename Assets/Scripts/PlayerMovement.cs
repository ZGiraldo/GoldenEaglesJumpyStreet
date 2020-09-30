using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerModel;
    public Animator anim;

    [SerializeField] float moveSpeed = 0;
    [SerializeField] float length = 0;
    [SerializeField] float rotationSpeed = 0;

    Vector3 targetPosition;
    Vector3 startPosition;
    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
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
                anim.SetBool("isJumping", false);
                return;
            }
            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovementDirection(Vector3.forward);
            RotatePlayer(-90, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MovementDirection(Vector3.back);
            RotatePlayer(-90, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MovementDirection(Vector3.left);
            RotatePlayer(-90, -90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MovementDirection(Vector3.right);
            RotatePlayer(-90, 90, 0);
        }

        Debug.DrawRay(transform.position, Vector3.forward * 0.5f, Color.red);
        Debug.DrawRay(transform.position, Vector3.back * 0.5f, Color.red);
        Debug.DrawRay(transform.position, Vector3.left * 0.5f, Color.red);
        Debug.DrawRay(transform.position, Vector3.right * 0.5f, Color.red);

    }

    void MovementDirection(Vector3 direction)
    {

        if (!Physics.Raycast(transform.position, direction, length))
        {
            targetPosition = transform.position + direction;
            startPosition = transform.position;
            isMoving = true;

            anim.SetBool("isJumping", true);
        }

    }

    void RotatePlayer(float x, float y, float z)
    {
        Quaternion target = Quaternion.Euler(x, y, z);
        playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, target, rotationSpeed);
    }
}
