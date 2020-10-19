using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerModel;
    public Animator anim;
    public bool isDead;

    [SerializeField] float moveSpeed = 0;
    [SerializeField] float length = 0;
    [SerializeField] float rotationSpeed = 0;

    Vector3 targetPosition;
    Vector3 startPosition;
    bool isMoving;
    bool onLog;
   

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

    //colliders

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            onLog = true;
            transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = null;
        onLog = false;
    }

    //functions

    void Movement()
    {
        if (isMoving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;

                if (!onLog)
                {
                    //transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
                    transform.position = new Vector3(Mathf.Lerp(transform.position.x, Mathf.Round(transform.position.x), 300 * Time.deltaTime), transform.position.y, transform.position.z);
                }

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
            RotatePlayer(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MovementDirection(Vector3.back);
            RotatePlayer(180);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MovementDirection(Vector3.left);
            RotatePlayer(-90);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MovementDirection(Vector3.right);
            RotatePlayer(90);
        }

        Debug.DrawRay(transform.position, Vector3.forward * 0.5f, Color.red);
        Debug.DrawRay(transform.position, Vector3.back * 0.5f, Color.red);
        Debug.DrawRay(transform.position, Vector3.left * 0.5f, Color.red);
        Debug.DrawRay(transform.position, Vector3.right * 0.5f, Color.red);

    }

    void MovementDirection(Vector3 direction)
    {
        DeathChecker();
        if (!isDead)
        {
            if (!Physics.Raycast(transform.position, direction, length))
            {
                targetPosition = transform.position + direction;
                startPosition = transform.position;
                isMoving = true;
                anim.SetBool("isJumping", true);
                FindObjectOfType<AudioManager>().Play("Jump");
            }
        }
    }

    void RotatePlayer(float y)
    {
        Quaternion target = Quaternion.Euler(-90, y, 0);
        playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, target, rotationSpeed);
    }

    void DeathChecker()
    {
        if (transform.position.y < 0.60f)
        {
            isDead = true;
        }
    }
}
