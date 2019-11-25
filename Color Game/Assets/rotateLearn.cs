using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLearn : MonoBehaviour
{
    [SerializeField] private Transform rotationPivotTransform;
    [SerializeField] private float angularSpeed = 90; //degrees per second 
    [SerializeField] private float targetRotationAngle; //degrees
    private float currentRotationAngle = 0; //degrees private Vector3 rotationAxis;

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
            float deltaAngle = angularSpeed * Time.deltaTime;
            if (currentRotationAngle + deltaAngle >= targetRotationAngle)
            {
                deltaAngle = targetRotationAngle - currentRotationAngle;
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
