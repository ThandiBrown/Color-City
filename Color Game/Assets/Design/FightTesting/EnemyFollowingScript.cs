using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowingScript : MonoBehaviour
{
    public float moveSpeed;
    public float gravityScale;
    public float jumpForce;
    //public CharacterController controller;
    Vector3 moveDirection;
    public bool manDown = false;
    float wakeUpTime;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > wakeUpTime && wakeUpTime !=0)
        {
            wakeUpTime = 0;
            transform.Rotate(90, transform.eulerAngles.y, transform.eulerAngles.z);
            //controller.enabled = false;
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            //controller.transform.position = new Vector3(controller.transform.position.x, 1, controller.transform.position.z);
            //controller.enabled = true;
            moveSpeed = 2;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        //controller.Move(moveDirection * Time.deltaTime);
    }

    public void FallDown()
    {
        wakeUpTime = Time.time + 15f;
        manDown = true;
        transform.Rotate(-90, transform.eulerAngles.y, transform.eulerAngles.z);
        //controller.enabled = false;
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        //controller.transform.position = new Vector3(controller.transform.position.x, 0.5f, controller.transform.position.z);
        //controller.enabled = true;
        moveSpeed = 0;
    }
}
