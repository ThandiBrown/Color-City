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
    bool spin = false;
    float startingPosition;
    float startRot;
    bool next = false;
    bool counterSpin = false;
    void Start()
    {
        
        
    }

    void Update()
    {
        if (false)
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
        

        if (Input.GetMouseButtonDown(1))
        {
            if (next)
            {
                startRot = transform.rotation.x;
                counterSpin = true;
                Debug.Log(startRot);
            }
            else
            {
                startRot = transform.rotation.x;
                spin = true;
                Debug.Log(startRot);
            }
            
        }

        if (spin)
        {
            transform.RotateAround(pivot.transform.position, Vector3.right, 1700f * Time.deltaTime);
            Debug.Log(transform.rotation.x);
            
        }

        if (counterSpin)
        {
            transform.RotateAround(pivot.transform.position, -Vector3.right, 1700f * Time.deltaTime);
            Debug.Log(transform.rotation.x);
            if (transform.rotation.x >= startRot)
            {
                counterSpin = false;
                next = false;
                //transform.eulerAngles = new Vector3(startRot, transform.eulerAngles.y, transform.eulerAngles.z);
                Debug.Log("there");
                
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Stopper1")
        {
            Debug.Log("Stopper1");
        }

        if (other.transform.name == "Stopper2")
        {
            Debug.Log("bbb" + transform.rotation.x);
            Debug.Log("Stop");
            if (spin) spin = !spin;
        }

        if (other.gameObject != thePlayer && other.transform.name == "Stopper2" && other.transform.name == "Stopper1")
        {
            Destroy(other.gameObject);
        }

        
    }
}
