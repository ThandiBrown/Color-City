using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : MonoBehaviour
{
    public static bool jabIsHappening = false, swingIsHappening = false;

    public GameObject thePlayer;
    public GameObject pivot;
    Transform target;
    private Vector3 targetPoint;

    public float moveSpeed = 5f;
    public float speedMultiplier = 1f;
    public float length = 1f;

    public static float killCount = 0;

    bool forward = false;
    bool backward = false;
    float startingZPosition;
    float startingYPosition;

    [SerializeField] private Transform rotationPivotTransform;
    [SerializeField] private float angleSpeed = 608f; //degrees per second 
    [SerializeField] private float rotateAmount = 152f; //degrees
    private float currentRotationAngle; //degrees private Vector3 rotationAxis;

    bool next = false, swingLeft = false, swingRight = false, swingIt = false;
    bool jabRight = false, jabLeft = false;
    bool pointingLeft = false, pointingRight = false;
    bool swingActive = false, jabActive = false;
    bool killAbilityActive;

    void Start()
    {
        killAbilityActive = false;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1) && !jabActive && !swingActive)
        {
            jabActive = true;
            jabIsHappening = true;
            killAbilityActive = true;

            startingZPosition = transform.position.z;
            startingYPosition = transform.position.y;
            Debug.Log(startingZPosition);
            Debug.Log(startingZPosition - length);
            forward = true;
            if (!pointingLeft && !pointingRight) jabRight = true;
            if (pointingLeft) jabLeft = true;
            if (pointingRight) jabRight = true;
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
                jabActive = false;
                jabIsHappening = false;
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
                jabActive = false;
                jabIsHappening = false;
            }
        }
        
        if (Input.GetMouseButtonDown(1) && !Input.GetMouseButton(0) && !jabActive && !swingActive)
        {
            swingIt = true;
            swingActive = true;
            swingIsHappening = true;
            killAbilityActive = true;

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
            if (!swingIt)
            {
                swingActive = false;
                swingIsHappening = false;
            }

        }
        
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject != thePlayer && !other.transform.IsChildOf(thePlayer.transform) && killAbilityActive)
        {
            killAbilityActive = false;
            killCount++;
            Destroy(other.gameObject);
        }
        
    }
}
