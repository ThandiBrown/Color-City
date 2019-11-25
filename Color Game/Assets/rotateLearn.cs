using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLearn : MonoBehaviour
{
    [SerializeField] private Transform rotationPivotTransform;
    [SerializeField] private float angleSpeed; //degrees per second 
    [SerializeField] private float rotateAmount; //degrees
    private float currentRotationAngle; //degrees private Vector3 rotationAxis;

    bool next = false, swingLeft = false, swingRight = false, swingIt = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentRotationAngle = 0;
            if (next)
            {
                swingRight = true;
                swingLeft = false;
            }
            else
            {
                swingLeft = true;
                swingRight = false;
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
                
                Transform thePivot = transform.parent.transform.GetChild(0);
                rotationPivotTransform = thePivot;
            }

            if(swingLeft) transform.RotateAround(rotationPivotTransform.position, Vector3.right, deltaAngle);
            if (swingRight) transform.RotateAround(rotationPivotTransform.position, Vector3.left, deltaAngle);
            currentRotationAngle += deltaAngle;
        }

    }

    /*
     * other thing
     * if (false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startingPosition = transform.position.z;
                Debug.Log(startingPosition);
                Debug.Log(startingPosition - length);
                forward = true;
            }

            if (forward)
                transform.Translate(Vector3.down * moveSpeed * speedMultiplier * Time.deltaTime);

            if (backward)
                transform.Translate(-Vector3.down * moveSpeed * Time.deltaTime);

            if (transform.position.z <= startingPosition - length)
            {
                Debug.Log("less");
                forward = false;
                backward = true;
            }
            else if (transform.position.z > startingPosition)
            {
                Debug.Log("greater");
                backward = false;
            }
        }
        */




    /*
     * 
     * if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("1: " + targetRotationAngle);
            goforit = true;
            targetRotationAngle += 120;
            Debug.Log("2: " + targetRotationAngle);
        }

        if (goforit)
        {
            float deltaAngle = angularSpeed * Time.deltaTime;
            Debug.Log("3: " + deltaAngle);
            if (currentRotationAngle + deltaAngle >= targetRotationAngle)
            {
                deltaAngle = targetRotationAngle - currentRotationAngle;
                Debug.Log("here");
                goforit = false;
                return;
            }

            transform.RotateAround(rotationPivotTransform.position, Vector3.right, deltaAngle);
            currentRotationAngle += deltaAngle;
        }*/


}
