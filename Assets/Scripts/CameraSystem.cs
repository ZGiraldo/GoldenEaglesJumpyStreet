using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem: MonoBehaviour
{
    [SerializeField] float defaultSpeed = 0;
    [SerializeField] float fastSpeed = 0;
    [SerializeField] float loseDistance = 0;
    [SerializeField] float speedUpDistance = 0;
    [SerializeField] bool isMoving;
    [SerializeField] Transform playerTransform = null;

  
    //[SerializeField] float smooth = 0;
    [SerializeField] Vector3 offset = new Vector3(0,0,0);

    float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            MoveCamera();
            DistanceChecker();
        }
        //Debug.Log(moveSpeed);
    }

    void MoveCamera()
    {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }

    void DistanceChecker()
    {
        float distanceToPlayer = playerTransform.position.z -  transform.position.z;
        Debug.Log(distanceToPlayer);

        if (distanceToPlayer > speedUpDistance)
        {
            //transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, smooth);
            moveSpeed = Mathf.Lerp(moveSpeed, fastSpeed, Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, defaultSpeed, Time.deltaTime);
        }

        if( distanceToPlayer < loseDistance)
        {
            isMoving = false;
            //Player is dead
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.right) * 5;
        Gizmos.DrawRay(transform.position + offset, direction);
        Vector3 direction2 = transform.TransformDirection(Vector3.left) * 5;
        Gizmos.DrawRay(transform.position + offset, direction2);
    }
}
