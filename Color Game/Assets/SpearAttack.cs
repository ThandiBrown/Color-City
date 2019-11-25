using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject pivot;
    Transform target;
    private Vector3 targetPoint;

    public float moveSpeed;
    public float speedMultiplier;
    public float length;
    bool forward = false;
    bool backward = false;
    float startingZPosition;
    float startingYPosition;


    [SerializeField] private Transform rotationPivotTransform;
    [SerializeField] private float angleSpeed; //degrees per second 
    [SerializeField] private float rotateAmount; //degrees
    private float currentRotationAngle; //degrees private Vector3 rotationAxis;

    bool next = false, swingLeft = false, swingRight = false, swingIt = false;
    bool jabRight = false, jabLeft = false;
    bool pointingLeft = false, pointingRight = false;
    void Start()
    {
        
        
    }

    void LateUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!jabLeft && !jabRight)
            {
                startingZPosition = transform.position.z;
                startingYPosition = transform.position.y;
                Debug.Log(startingZPosition);
                Debug.Log(startingZPosition - length);
                forward = true;
                if (!pointingLeft && !pointingRight) jabRight = true;
                if (pointingLeft) jabLeft = true;
                if (pointingRight) jabRight = true;
            }
        }

        if (jabRight)
        {
            if (forward)
                transform.Translate(Vector3.down * moveSpeed * speedMultiplier * Time.deltaTime);
            
            if (backward)
                transform.Translate(-Vector3.down * moveSpeed * Time.deltaTime);
            
            if (transform.position.z <= startingZPosition - length)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, startingZPosition - length);
                forward = false;
                backward = true;
            }
            else if (transform.position.z > startingZPosition)
            {
                transform.position = new Vector3(transform.position.x, startingYPosition, startingZPosition);
                backward = false;
                jabRight = false;
            }
        }

        if (jabLeft)
        {
            if (forward)
                transform.Translate(Vector3.down * moveSpeed * speedMultiplier * Time.deltaTime);

            if (backward)
                transform.Translate(-Vector3.down * moveSpeed * Time.deltaTime);

            if (transform.position.z >= startingZPosition + length)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, startingZPosition + length);
                forward = false;
                backward = true;
            }
            else if (transform.position.z < startingZPosition)
            {
                transform.position = new Vector3(transform.position.x, startingYPosition, startingZPosition);
                backward = false;
                jabLeft = false;
            }
        }

        if (true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                currentRotationAngle = 0;
                if (next)
                {
                    swingRight = true;
                    swingLeft = false;
                    pointingRight = true;
                    pointingLeft = false;
                }
                else
                {
                    swingLeft = true;
                    swingRight = false;
                    pointingLeft = true;
                    pointingRight = false;
                }
                swingIt = true;
            }

            if (swingIt)
            {
                float deltaAngle = angleSpeed * Time.deltaTime;
                if (currentRotationAngle + deltaAngle >= rotateAmount)
                {
                    deltaAngle = rotateAmount - currentRotationAngle;
                    enabled = false;
                    enabled = true;
                    swingIt = false;
                    next = !next;

                    Transform thePivot = transform.parent.transform.GetChild(2);
                    rotationPivotTransform = thePivot;
                }

                if (swingLeft) transform.RotateAround(rotationPivotTransform.position, Vector3.right, deltaAngle);
                if (swingRight) transform.RotateAround(rotationPivotTransform.position, Vector3.left, deltaAngle);
                currentRotationAngle += deltaAngle;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != thePlayer && !other.transform.IsChildOf(thePlayer.transform))
        {
            Destroy(other.gameObject);
        }
    }
}
